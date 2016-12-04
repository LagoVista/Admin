using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.PlatformSupport;
using LagoVista.UserManagement.Interfaces.Repos.Security;
using LagoVista.UserManagement.Models.Account;
using LagoVista.Web.Identity.Interfaces;
using System.Threading.Tasks;
using System;

namespace LagoVista.Web.Identity.Repos.Security
{
    public class RoleRepo : DocumentDBRepoBase<Role>, IRoleRepo
    {
        public RoleRepo(IAppUserManagementSettings settings, ILogger logger) : base(settings.UserStorage.Uri, settings.UserStorage.AccessKey, settings.UserStorage.ResourceName, logger)
        {

        }

        public Task AddRoleAsync(string organizationId, Role role)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public Task InsertAsync(Role role)
        {
            return CreateDocumentAsync(role);
        }

        public Task RemoveAsync(string id, string etag = "*")
        {
            return DeleteDocumentAsync(id);
        }

        public Task UpdateAsync(Role role)
        {
            return base.UpsertDocumentAsync(role);
        }
    }
}
