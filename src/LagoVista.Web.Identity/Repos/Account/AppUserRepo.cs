﻿using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.PlatformSupport;
using LagoVista.UserManagement.Interfaces.Repos.Account;
using LagoVista.UserManagement.Models.Account;
using LagoVista.Web.Identity.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.Web.Identity.Repos.Account
{
    public class AppUserRepo : DocumentDBRepoBase<AppUser>, IAppUserRepo
    {
        bool _shouldConsolidateCollections;
        public AppUserRepo(IAppUserManagementSettings userManagementSettings, ILogger logger) : 
            base(userManagementSettings.UserStorage.Uri, userManagementSettings.UserStorage.AccessKey, userManagementSettings.UserStorage.ResourceName, logger)
        {
            _shouldConsolidateCollections = userManagementSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections
        {
            get { return _shouldConsolidateCollections; }
        }

        public async Task CreateAsync(AppUser user)
        {
            await CreateDocumentAsync(user);
        }

        public async Task DeleteAsync(AppUser user)
        {
            await DeleteAsync(user);
        }

        public Task<AppUser> FindByIdAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public async Task<AppUser> FindByNameAsync(string userName)
        {
            return (await QueryAsync(usr => usr.UserName == userName.ToLower())).FirstOrDefault();
        }

        public async Task<AppUser> FindByEmailAsync(string email)
        {
            return (await QueryAsync(usr => usr.Email == email.ToUpper())).FirstOrDefault();
        }

        public async Task UpdateAsync(AppUser user)
        {
            await Client.UpsertDocumentAsync(await GetCollectionDocumentsLinkAsync(), user);
        }
        
        public Task<AppUser> FindByThirdPartyLogin(string providerId, string providerKey)
        {
            throw new NotImplementedException();
        }
    }
}
