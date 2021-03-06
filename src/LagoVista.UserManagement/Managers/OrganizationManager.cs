﻿using LagoVista.Core.Models;
using LagoVista.Core.PlatformSupport;
using LagoVista.UserManagement.Interfaces.Repos.Orgs;
using LagoVista.UserManagement.Interfaces.Repos.Account;
using LagoVista.UserManagement.ViewModels.Organization;
using System;
using System.Threading.Tasks;
using LagoVista.UserManagement.Resources;
using System.Collections.Generic;
using LagoVista.UserManagement.Interfaces.Managers;
using LagoVista.UserManagement.Models.Orgs;
using LagoVista.UserManagement.Models.Account;
using LagoVista.UserManagement.Interfaces;
using LagoVista.Core.Exceptions;
using LagoVista.Core;
using LagoVista.UserManagement.Models.Security;
using LagoVista.UserManagement.Interfaces.Repos.Security;
using System.Linq;
using LagoVista.Core.Managers;
using LagoVista.Core.Interfaces;

namespace LagoVista.UserManagement.Managers
{
    public class OrganizationManager : ManagerBase, IOrganizationManager
    {
        #region Fields
        readonly IOrganizationRepo _organizationRepo;
        readonly IOrganizationLocationRepo _locationRepo;
        readonly IOrganizationAccountRepo _orgAccountRepo;
        readonly ILocationAccountRepo _locationAccountRepo;
        readonly ISmsSender _smsSender;
        readonly IEmailSender _emailSender;
        readonly IInviteUserRepo _inviteUserRepo;
        readonly ILocationRoleRepo _locationRoleRepo;
        readonly IOrganizationRoleRepo _orgRoleRepo;
        readonly IAppUserRepo _appUserRepo;
        #endregion

        #region Ctor
        public OrganizationManager(IOrganizationRepo organizationRepo,
            IOrganizationLocationRepo locationRepo,
            IOrganizationAccountRepo orgAccountRepo,
            IAppUserRepo appUserRepo,
            IInviteUserRepo inviteUserRepo,
            ILocationAccountRepo locationAccountRepo,
            ILocationRoleRepo locationRoleRepo,
            IOrganizationRoleRepo orgRoleRepo,
            ISmsSender smsSender,
            IEmailSender emailSender,
            IAppConfig appConfig,
            ILogger logger) : base( logger, appConfig)
        {

            _appUserRepo = appUserRepo;
            _organizationRepo = organizationRepo;
            _orgAccountRepo = orgAccountRepo;
            _locationRepo = locationRepo;
            _locationAccountRepo = locationAccountRepo;

            _orgRoleRepo = orgRoleRepo;
            _locationRoleRepo = locationRoleRepo;

            _smsSender = smsSender;
            _emailSender = emailSender;
            _inviteUserRepo = inviteUserRepo;
        }
        #endregion

        #region Organizations
        public async Task<bool> QueryOrgNamespaceInUseAsync(string namespaceText)
        {
            return await _organizationRepo.QueryNamespaceInUseAsync(namespaceText);
        }

        public async Task CreateNewOrganizationAsync(CreateOrganizationViewModel organizationViewModel, EntityHeader user)
        {
            ValidationCheck(organizationViewModel, Core.Validation.Actions.Create);

            //HACK: Very, small chance, but it does exist...two entries could be added at exact same time and check would fail...need to make progress, can live with rish for now.
            if (await _organizationRepo.QueryNamespaceInUseAsync(organizationViewModel.Namespace))
            {
                throw new ValidationException(Resources.UserManagementResources.Organization_CantCreate, false,
                                   UserManagementResources.Organization_NamespaceInUse.Replace(Tokens.NAMESPACE, organizationViewModel.Namespace));
            }

            var organization = new Organization();
            organization.SetId();
            organization.SetCreationUpdatedFields(user);
            organizationViewModel.MapToOrganization(organization);
            organization.Status = UserManagementResources.Organization_Status_Active;
            organization.TechnicalContact = user;
            organization.AdminContact = user;
            organization.BillingContact = user;

            var location = new OrganizationLocation();
            location.SetId();
            organizationViewModel.MapToOrganizationLocation(location);
            location.SetCreationUpdatedFields(user);
            location.AdminContact = user;
            location.TechnicalContact = user;
            location.Organization = organization.ToEntityHeader();

            organization.PrimaryLocation = location.ToEntityHeader();

            if (organization.Locations == null) organization.Locations = new List<EntityHeader>();
            organization.Locations.Add(location.ToEntityHeader());

            var currentUser = await _appUserRepo.FindByIdAsync(user.Id);
            var locationUser = new LocationAccount(organization.Id, location.Id, user.Id)
            {
                Email = currentUser.Email,
                OrganizationName = organization.Name,
                AccountName = currentUser.Name,
                ProfileImageUrl = currentUser.ProfileImageUrl.ImageUrl,
                LocationName = location.Name
            };
            locationUser.SetCreationUpdatedFields(user);

            await _organizationRepo.AddOrganizationAsync(organization);
            await AddAccountToOrgAsync(currentUser.ToEntityHeader(), organization.ToEntityHeader(), currentUser.ToEntityHeader());
            await _locationRepo.AddLocationAsync(location);
            await _locationAccountRepo.AddAccountToLocationAsync(locationUser);

            if (EntityHeader.IsNullOrEmpty(currentUser.CurrentOrganization)) currentUser.CurrentOrganization = organization.ToEntityHeader();
            if (currentUser.Organizations == null) currentUser.Organizations = new List<EntityHeader>();

            currentUser.Organizations.Add(organization.ToEntityHeader());

            await _appUserRepo.UpdateAsync(currentUser);
        }

        public async Task UpdateOrganizationAsync(UpdateOrganizationViewModel orgViewModel, EntityHeader user)
        {
            ValidationCheck(orgViewModel, Core.Validation.Actions.Update);

            var org = await _organizationRepo.GetOrganizationAsync(orgViewModel.OrganziationId);
            org.SetLastUpdatedFields(user);
            ConcurrencyCheck(org, orgViewModel.LastUpdatedDate);

            await _organizationRepo.UpdateOrganizationAsync(org);
        }

        public async Task<UpdateOrganizationViewModel> GetUpdateOrganizationViewModel(string organizationId)
        {
            var org = await _organizationRepo.GetOrganizationAsync(organizationId);
            return UpdateOrganizationViewModel.CreateFromOrg(org);
        }

        public Task<Organization> GetOrganizationAsync(string organizationId)
        {
            return _organizationRepo.GetOrganizationAsync(organizationId);
        }
        #endregion

        #region Invite User
        public async Task AcceptInvitationAsync(AcceptInviteViewModel acceptInviteViewModel, String acceptedUserId)
        {
            var invite = await _inviteUserRepo.GetInvitationAsync(acceptInviteViewModel.InviteId);
            invite.Accepted = true;
            invite.Status = Invitation.StatusTypes.Accepted;
            invite.DateAccepted = DateTime.Now.ToJSONString();
            await _inviteUserRepo.UpdateInvitationAsync(invite);

            var acceptedUser = await _appUserRepo.FindByIdAsync(acceptedUserId);
            var invitingUser = EntityHeader.Create(invite.InvitedById, invite.InvitedByName);
            var orgHeader = EntityHeader.Create(invite.OrganizationId, invite.OrganizationName);

            await AddAccountToOrgAsync(acceptedUser.ToEntityHeader(), orgHeader, invitingUser);

            if (acceptedUser.CurrentOrganization == null || acceptedUser.CurrentOrganization.IsEmpty())
            {
                acceptedUser.CurrentOrganization = orgHeader;
            }

            acceptedUser.Organizations.Add(orgHeader);

            await _appUserRepo.UpdateAsync(acceptedUser);
        }

        public async Task RevokeInvitationAsync(String inviteId)
        {
            var invite = await _inviteUserRepo.GetInvitationAsync(inviteId);
            invite.Status = Invitation.StatusTypes.Revoked;
            await _inviteUserRepo.UpdateInvitationAsync(invite);
        }

        public async Task DeclineInvitationAsync(String inviteId)
        {
            var invite = await _inviteUserRepo.GetInvitationAsync(inviteId);
            invite.Status = Invitation.StatusTypes.Declined;
            await _inviteUserRepo.UpdateInvitationAsync(invite);
        }

        public async Task<AcceptInviteViewModel> GetInviteViewModelAsync(String inviteId)
        {
            var invite = await _inviteUserRepo.GetInvitationAsync(inviteId);

            return AcceptInviteViewModel.CreateFromInvite(invite);
        }

        public async Task<Invitation> InviteUserAsync(InviteUserViewModel inviteViewModel, EntityHeader orgEntityHeader, EntityHeader userEntityHeader)
        {
            if (await _orgAccountRepo.QueryOrganizationHasAccountByEmailAsync(orgEntityHeader.Id, inviteViewModel.Email))
            {
                var existingUser = await _appUserRepo.FindByEmailAsync(inviteViewModel.Email);
                var msg = UserManagementResources.InviteUser_AlreadyPartOfOrg.Replace(Tokens.USERS_FULL_NAME, existingUser.Name).Replace(Tokens.EMAIL_ADDR, inviteViewModel.Email);
                throw new ValidationException("Could not invite user", false, msg);
            }

            var invite = await _inviteUserRepo.GetInviteByOrgIdAndEmailAsync(orgEntityHeader.Id, inviteViewModel.Email);
            if(invite != null)
            {
                invite.Status = Invitation.StatusTypes.Replaced;
                await _inviteUserRepo.UpdateInvitationAsync(invite);
            }

            var inviteModel = new Invitation()
            {
                RowKey = Guid.NewGuid().ToId(),
                PartitionKey = orgEntityHeader.Id,
                OrganizationId = orgEntityHeader.Id,
                OrganizationName = orgEntityHeader.Text,
                InvitedById = userEntityHeader.Id,
                InvitedByName = userEntityHeader.Text,
                Name = inviteViewModel.Name,
                Email = inviteViewModel.Email,
                DateSent = DateTime.Now.ToJSONString(),
                Status = Invitation.StatusTypes.New,
            };

            await _inviteUserRepo.InsertInvitationAsync(inviteModel);

            var subject = Resources.UserManagementResources.Invite_Greeting_Subject.Replace(Tokens.APP_NAME, AppConfig.AppName).Replace(Tokens.ORG_NAME, orgEntityHeader.Text);
            var message = Resources.UserManagementResources.InviteUser_Greeting_Message.Replace(Tokens.USERS_FULL_NAME, userEntityHeader.Text).Replace(Tokens.ORG_NAME, orgEntityHeader.Text).Replace(Tokens.APP_NAME, AppConfig.AppName);
            message += $"<br /><br />{inviteViewModel.Message}<br /><br />";
            var acceptLink = $"{AppConfig.WebAddress}/organization/acceptinvite/{inviteModel.RowKey}";

            message += Resources.UserManagementResources.InviteUser_ClickHere.Replace("[ACCEPT_LINK]", acceptLink);

            await _emailSender.SendAsync(inviteModel.Email, subject, message);

            inviteModel = await _inviteUserRepo.GetInvitationAsync(inviteModel.RowKey);
            inviteModel.DateSent = DateTime.Now.ToJSONString();
            inviteModel.Status = Invitation.StatusTypes.Sent;
            await _inviteUserRepo.UpdateInvitationAsync(inviteModel);

            return inviteModel;
        }
        #endregion

        #region Organization Account Methods
        public async Task AddAccountToOrgAsync(EntityHeader userToAdd, EntityHeader org, EntityHeader addedBy = null)
        {
            var appUser = await _appUserRepo.FindByIdAsync(userToAdd.Id);

            if (await _orgAccountRepo.QueryOrganizationHasAccountAsync(org.Id, userToAdd.Id))
            {
                throw new ValidationException(Resources.UserManagementResources.OrganizationAccount_CouldntAdd, false,
                    UserManagementResources.OrganizationAccount_UserExists.Replace(Tokens.USERS_FULL_NAME, appUser.Name).Replace(Tokens.ORG_NAME, org.Text));
            }

            var accountUser = new OrganizationAccount(org.Id, userToAdd.Id)
            {
                Email = appUser.Email,
                OrganizationName = org.Text,
                AccountName = appUser.Name,
                ProfileImageUrl = appUser.ProfileImageUrl.ImageUrl,
            };

            accountUser.CreatedBy = addedBy != null ? addedBy.Text : userToAdd.Text;
            accountUser.CreatedById = addedBy != null ? addedBy.Id : userToAdd.Id;
            accountUser.CreationDate = DateTime.Now.ToJSONString();
            accountUser.LastUpdatedBy = appUser.Name;
            accountUser.LastUpdatedById = appUser.Id;
            accountUser.LastUpdatedDate = accountUser.CreationDate;
            await _orgAccountRepo.AddAccountUserAsync(accountUser);
        }

        public Task<IEnumerable<OrganizationAccount>> GetAccountsForOrganizationsAsync(string orgId)
        {
            return _orgAccountRepo.GetAccountsForOrganizationAsync(orgId);
        }

        public Task<IEnumerable<OrganizationAccount>> GetOrganizationsForAccountAsync(string accountId)
        {
            return _orgAccountRepo.GetOrganizationsForAccountAsync(accountId);
        }

        public Task RemoveAccountFromOrganizationAsync(EntityHeader account, EntityHeader org, EntityHeader removedBy)
        {
            return _orgAccountRepo.RemoveAccountFromOrgAsync(account, org, removedBy);
        }

        public Task<bool> QueryOrganizationHasAccountAsync(string orgId, string accountId)
        {
            return _orgAccountRepo.QueryOrganizationHasAccountAsync(orgId, accountId);
        }
        #endregion

        #region Organization Location
        public async Task<bool> QueryLocationNamespaceInUseAsync(string orgId, string namespaceText)
        {
            return await _locationRepo.QueryNamespaceInUseAsync(orgId, namespaceText);
        }

        public async Task<IEnumerable<OrganizationLocation>> GetLocationsForOrganizationsAsync(String orgId)
        {
            return (await _locationRepo.GetOrganizationLocationAsync(orgId)).ToList();
        }

        public async Task AddLocationAsync(CreateLocationViewModel newLocation, EntityHeader addedByUser)
        {
            ValidationCheck(newLocation, Core.Validation.Actions.Create);

            var location = new OrganizationLocation();
            location.SetId();

            var currentUser = await _appUserRepo.FindByIdAsync(addedByUser.Id);
            var organization = await _organizationRepo.GetOrganizationAsync(newLocation.OrganizationId);

            location.Organization = organization.ToEntityHeader();
            if (EntityHeader.IsNullOrEmpty(location.AdminContact)) location.AdminContact = addedByUser;
            if (EntityHeader.IsNullOrEmpty(location.TechnicalContact)) location.TechnicalContact = addedByUser;

            SetCreatedBy(location, addedByUser);

            await _locationRepo.AddLocationAsync(location);
        }

        public CreateLocationViewModel GetCreateLocationViewModel(EntityHeader org, EntityHeader user)
        {
            return CreateLocationViewModel.CreateNew(org, user);
        }

        public async Task<UpdateLocationViewModel> GetUpdateLocationViewModelAsync(String locationId)
        {
            var location = await _locationRepo.GetLocationAsync(locationId);
            return UpdateLocationViewModel.CreateForOrganizationLocation(location);
        }

        public async Task UpdateLocationAsync(UpdateLocationViewModel location, EntityHeader user)
        {
            ValidationCheck(location, Core.Validation.Actions.Update);

            var locationFromStorage = await _locationRepo.GetLocationAsync(location.LocationId);
            ConcurrencyCheck(locationFromStorage, location.LastUpdatedDate);
            SetLastUpdated(locationFromStorage, user);

            await _locationRepo.UpdateLocationAsync(locationFromStorage);
        }

        public Task<OrganizationAccountRoles> AddAccountRoleForOrgAsync(EntityHeader location, EntityHeader account, EntityHeader role, EntityHeader addedBy)
        {
            return _orgRoleRepo.AddRoleForAccountAsync(location, account, role, addedBy);
        }

        public Task<IEnumerable<OrganizationAccountRoles>> GetAccountRolesForOrgAsync(string orgId, string accountId)
        {
            return _orgRoleRepo.GetRolesForAccountAsync(accountId, orgId);
        }

        public Task<IEnumerable<OrganizationAccountRoles>> GetAccountsForRoleInOrgAsync(string orgId, string roleId)
        {
            return _orgRoleRepo.GetAccountsForRoleAsync(orgId, roleId);
        }

        public Task RevokeRoleForAccountInOrgAsync(EntityHeader org, EntityHeader role, EntityHeader account, EntityHeader revokedBy)
        {
            return _orgRoleRepo.RevokeRoleForAccountInOrgAsync(org, role, account, revokedBy);
        }

        public Task RevokeAllRolesForAccountInOrgAsync(EntityHeader org, EntityHeader account, EntityHeader revokedBy)
        {
            return _orgRoleRepo.RevokeAllRolesForAccountInOrgAsync(org, account, revokedBy);
        }
        #endregion

        #region Location Account
        public async Task AddAccountTosync(String accountId, String locationId, EntityHeader addedBy = null)
        {
            var appUser = await _appUserRepo.FindByIdAsync(accountId);
            var location = await _locationRepo.GetLocationAsync(locationId);

            var locationAccount = new LocationAccount(location.Organization.Id, locationId, accountId)
            {
                AccountName = appUser.Name
            };

            await _locationAccountRepo.AddAccountToLocationAsync(locationAccount);
        }

        public Task GetAccountsForLocationAsync(String locationId)
        {
            return _locationAccountRepo.GetAccountsForLocationAsync(locationId);
        }

        public Task<IEnumerable<LocationAccount>> GetLocationsForAccountAsync(String accountId)
        {
            return _locationAccountRepo.GetLocationsForAccountAsync(accountId);
        }

        public Task RemoveAccountFromLocation(String locationId, String accountId, EntityHeader removedBy)
        {
            return _locationAccountRepo.RemoveAccountFromLocationAsync(locationId, accountId, removedBy);
        }

        public Task<LocationAccountRoles> AddAccountRoleForLocationAsync(EntityHeader location, EntityHeader account, EntityHeader role, EntityHeader addedBy)
        {
            return _locationRoleRepo.AddRoleForAccountAsync(location, account, role, addedBy);
        }

        public Task<IEnumerable<LocationAccountRoles>> GetAccountRolesForLocationAsync(string locationId, string accountId)
        {
            return _locationRoleRepo.GetRolesForAccountInLocationAsync(locationId, accountId);
        }

        public Task<IEnumerable<LocationAccountRoles>> GetAccountsForRoleInLocationAsync(string locationId, string roleId)
        {
            return _locationRoleRepo.GetAccountsForRoleInLocationAsync(locationId, roleId);
        }

        public Task RevokeRoleForAccountInLocationAsync(EntityHeader location, EntityHeader role, EntityHeader account, EntityHeader revokedBy)
        {
            return _locationRoleRepo.RevokeRoleForAccountInLocationAsync(location, role, account, revokedBy);
        }

        public Task RevokeAllRolesForAccountInLocationAsync(EntityHeader location, EntityHeader account, EntityHeader revokedBy)
        {
            return _locationRoleRepo.RevokeAllRolesForAccountInLocationAsync(location, account, revokedBy);
        }
        #endregion
    }
}