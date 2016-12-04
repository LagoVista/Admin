using LagoVista.CloudStorage.DocumentDB;

using System;
using System.Threading.Tasks;
using LagoVista.Web.Identity.Interfaces;
using LagoVista.Core.PlatformSupport;
using System.Collections.Generic;
using LagoVista.UserManagement.Models.Orgs;
using LagoVista.UserManagement.Interfaces.Repos.Orgs;
using System.Linq;
using Microsoft.Azure.Documents;

namespace LagoVista.Web.Identity.Repos.Orgs
{
    public class OrganizationLocationRepo : DocumentDBRepoBase<OrganizationLocation>, IOrganizationLocationRepo
    {
        public OrganizationLocationRepo(IAppUserManagementSettings userManagementSettings, ILogger logger) :
            base(userManagementSettings.UserStorage.Uri, userManagementSettings.UserStorage.AccessKey, userManagementSettings.UserStorage.ResourceName, logger)
        {

        }

        public Task AddLocationAsync(OrganizationLocation account)
        {
            return CreateDocumentAsync(account);
        }

        public Task UpdateLocationAsync(OrganizationLocation account)
        {
            return UpsertDocumentAsync(account);
        }

        public Task<OrganizationLocation> GetLocationAsync(String id)
        {
            return GetDocumentAsync(id);
        }

        public Task<IEnumerable<OrganizationLocation>> GetOrganizationLocationAsync(String organizationId)
        {
            return QueryAsync(act => act.Organization.Id == organizationId);
        }

        public async Task<bool> QueryNamespaceInUseAsync(string orgId, string namespaceText)
        {
            try
            {
                var organization = (await QueryAsync(loc => loc.Namespace == namespaceText && loc.Organization.Id == orgId));
                return organization.ToList().Any();
            }
            catch(DocumentClientException)
            {
                /* If the collection doesn't exist, it will throw this exception */
                return false;
            }
        }
    }
}
