using LagoVista.Core.Attributes;
using System;
using LagoVista.UserManagement.Resources;
using LagoVista.Core.Models;
using LagoVista.UserManagement.Models.Orgs;
using LagoVista.UserManagement.Models;

namespace LagoVista.UserManagement.ViewModels.Organization
{
    [EntityDescription(Domains.UserViewModels, UserManagementResources.Names.AcceptInviteVM_Title, UserManagementResources.Names.AcceptInviteVM_Help, UserManagementResources.Names.AcceptInviteVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]
    public class AcceptInviteViewModel
    {
        [FormField(FieldType: FieldTypes.Hidden, IsRequired: true)]
        public string InviteId { get; set; }

        [FormField(LabelResource: UserManagementResources.Names.AppUser_FirstName, FieldType: FieldTypes.Text, IsRequired: true, ResourceType: typeof(UserManagementResources))]
        public String RegisterFirstName { get; set; }
        [FormField(LabelResource: UserManagementResources.Names.AppUser_LastName, FieldType: FieldTypes.Text, IsRequired: true, ResourceType: typeof(UserManagementResources))]
        public String RegisterLastName { get; set; }
        [FormField(LabelResource: UserManagementResources.Names.AppUser_Email, FieldType: FieldTypes.Email, IsRequired: true, ResourceType: typeof(UserManagementResources))]
        public String RegisterEmail { get; set; }
        [FormField(LabelResource: UserManagementResources.Names.AppUser_Password, FieldType: FieldTypes.Password, IsRequired: true, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string RegisterPassword { get; set; }
        [FormField(LabelResource: UserManagementResources.Names.AppUser_ConfirmPassword, CompareTo: nameof(RegisterPassword), CompareToMsgResource: UserManagementResources.Names.AppUser_PasswordConfirmPasswordMatch, FieldType: FieldTypes.Password, IsRequired: true, ResourceType: typeof(UserManagementResources))]
        public string RegisterConfirmPassword { get; set; }
        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_RememberMe, FieldType: FieldTypes.CheckBox, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public bool RegisterRememberMe { get; set; }



        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_Email, FieldType: FieldTypes.Email, IsRequired: true, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string LoginEmail { get; set; }
        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_Password, FieldType: FieldTypes.Password, IsRequired: true, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string LoginPassword { get; set; }
        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_RememberMe, FieldType: FieldTypes.CheckBox, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public bool LoginRememberMe { get; set; }



        [FormField(IsRequired: true, FieldType: FieldTypes.Hidden)]
        public String OrganizationId { get; set; }
        [FormField(IsRequired: true, FieldType: FieldTypes.Hidden)]
        public String OrganizationName { get; set; }


        [FormField(IsRequired: true, FieldType: FieldTypes.Hidden)]
        public String InvitedById { get; set; }
        [FormField(IsRequired: true, FieldType: FieldTypes.Hidden)]
        public String InvitedByName { get; set; }

         
        public bool Active { get; set; }

        public EntityHeader GetInvitedByEntityHeader() { return EntityHeader.Create(InvitedById, InvitedByName); }

        public EntityHeader GetOrgEntityHeader() { return EntityHeader.Create(OrganizationId, OrganizationName); }

        public static AcceptInviteViewModel CreateFromInvite(Invitation invite)
        {
            return new AcceptInviteViewModel()
            {
                Active = !invite.Accepted && !invite.Declined && 
                    (invite.Status == Invitation.StatusTypes.New || invite.Status == Invitation.StatusTypes.Sent),
                InviteId = invite.RowKey,
                InvitedById = invite.InvitedById,
                InvitedByName = invite.InvitedByName,
                OrganizationId = invite.OrganizationId,
                OrganizationName = invite.OrganizationName,
            };
        }
    }
}
