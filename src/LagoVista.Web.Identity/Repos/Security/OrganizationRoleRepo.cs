using LagoVista.UserManagement.Interfaces.Repos.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LagoVista.Core.Models;
using LagoVista.UserManagement.Models.Security;
using LagoVista.Web.Identity.Interfaces;
using LagoVista.Core.PlatformSupport;
using LagoVista.CloudStorage.Storage;

namespace LagoVista.Web.Identity.Repos.Security
{
    public class OrganizationRoleRepo : TableStorageBase<LocationAccountRoles>, IOrganizationRoleRepo
    {
        public OrganizationRoleRepo(IAppUserManagementSettings settings, ILogger logger) :
            base(settings.UserTableStorage.AccountId, settings.UserTableStorage.AccessKey, logger)
        {

        }

        public Task<OrganizationAccountRoles> AddRoleForAccountAsync(EntityHeader organization, EntityHeader account, EntityHeader role, EntityHeader addedBy)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrganizationAccountRoles>> GetAccountsForRoleAsync(string roleId, string organziationId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrganizationAccountRoles>> GetRolesForAccountAsync(string accountId, string organizationId)
        {
            throw new NotImplementedException();
        }

        public Task RevokeAllRolesForAccountInOrgAsync(EntityHeader org, EntityHeader account, EntityHeader revokedBy)
        {
            throw new NotImplementedException();
        }

        public Task RevokeRoleForAccountInOrgAsync(EntityHeader org, EntityHeader role, EntityHeader account, EntityHeader revokedBy)
        {
            throw new NotImplementedException();
        }
    }
}
