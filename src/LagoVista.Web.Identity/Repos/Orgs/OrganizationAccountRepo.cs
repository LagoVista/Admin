﻿using LagoVista.Core.PlatformSupport;
using LagoVista.UserManagement.Interfaces.Repos.Orgs;
using LagoVista.UserManagement.Models.Orgs;
using LagoVista.Web.Identity.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using LagoVista.Core.Models;
using System;
using LagoVista.CloudStorage.Storage;

namespace LagoVista.Web.Identity.Repos.Orgs
{
    public class OrganizationAccountRepo : TableStorageBase<OrganizationAccount>, IOrganizationAccountRepo
    {
        public OrganizationAccountRepo(IAppUserManagementSettings settings, ILogger logger) : base(settings.UserTableStorage.AccountId, settings.UserTableStorage.AccessKey, logger)
        {

        }

        public Task<IEnumerable<OrganizationAccount>> GetUsersForAccount(string accountId)
        {
            return GetByParitionIdAsync(accountId);
        }

        public async Task<bool> QueryOrganizationHasAccountAsync(string orgId, string accountId)
        {
            return (await base.GetAsync(OrganizationAccount.CreateRowKey(orgId, accountId))) != null;
        }

        public async Task<OrganizationAccount> AddAccountUserAsync(OrganizationAccount accountUser)
        {
            await InsertAsync(accountUser);

            return accountUser;
        }

        public Task<IEnumerable<OrganizationAccount>> GetOrganizationsForAccountAsync(string accountId)
        {
            return GetByFilterAsync(FilterOptions.Create("AccountId", FilterOptions.Operators.Equals, accountId));
        }

        public Task<IEnumerable<OrganizationAccount>> GetAccountsForOrganizationAsync(string organizationId)
        {
            return GetByParitionIdAsync(organizationId);
        }

        public Task RemoveAccountFromOrgAsync(EntityHeader account, EntityHeader org, EntityHeader removedBy)
        {
            var rowKey = OrganizationAccount.CreateRowKey(org.Id, account.Id);
            return RemoveAsync(account.Id, rowKey);
        }

        public async Task<bool> QueryOrganizationHasAccountByEmailAsync(string organizationId, string email)
        {
            return (await GetByFilterAsync(
                FilterOptions.Create("Email", FilterOptions.Operators.Equals, email.ToUpper()),
                FilterOptions.Create("OrganizationId", FilterOptions.Operators.Equals, organizationId)
                )).ToList().Any();
        }
    }
}
