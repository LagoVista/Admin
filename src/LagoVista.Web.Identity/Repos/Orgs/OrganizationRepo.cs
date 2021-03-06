﻿using System.Threading.Tasks;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Web.Identity.Interfaces;
using LagoVista.Core.PlatformSupport;
using System.Linq;
using LagoVista.UserManagement.Models.Orgs;
using LagoVista.UserManagement.Interfaces.Repos.Orgs;
using Microsoft.Azure.Documents;

namespace LagoVista.Web.Identity.Repos.Orgs
{
    public class OrganizationRepo : DocumentDBRepoBase<Organization>, IOrganizationRepo
    {
        bool _shouldConsolidateCollections;        

        public OrganizationRepo(IAppUserManagementSettings userManagementSettings, ILogger logger) :
            base(userManagementSettings.UserStorage.Uri, userManagementSettings.UserStorage.AccessKey, userManagementSettings.UserStorage.ResourceName, logger)
        {
            _shouldConsolidateCollections = userManagementSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections
        {
            get { return _shouldConsolidateCollections; }
        }

        public Task AddOrganizationAsync(Organization account)
        {
            return CreateDocumentAsync(account);
        }

        public Task<Organization> GetOrganizationAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public async Task<bool> QueryNamespaceInUseAsync(string namespaceText)
        {
            try
            {
                var organization = (await QueryAsync(org => org.Namespace == namespaceText));
                var list = organization.ToList();
                return list.Any();
            }
            catch(DocumentClientException)
            {
                /* If the collection doesn't exist, it will throw this exception */
                return false;
            }
        }

        public async Task<bool> QueryOrganizationExistAsync(string id)
        {
            return (await GetOrganizationAsync(id)) != null;
        }

        public Task UpdateOrganizationAsync(Organization account)
        {
            return UpsertDocumentAsync(account);
        }

    }
}