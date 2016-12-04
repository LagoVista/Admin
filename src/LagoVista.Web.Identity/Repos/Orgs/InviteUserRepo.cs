using LagoVista.UserManagement.Interfaces.Repos.Orgs;
using System.Threading.Tasks;
using LagoVista.UserManagement.Models.Orgs;
using LagoVista.CloudStorage.Storage;
using LagoVista.Web.Identity.Interfaces;
using LagoVista.Core.PlatformSupport;
using System.Linq;
using System;

namespace LagoVista.Web.Identity.Repos.Orgs
{
    public class InviteUserRepo : TableStorageBase<Invitation>, IInviteUserRepo
    {
        public InviteUserRepo(IAppUserManagementSettings settings, ILogger logger) :
            base(settings.UserTableStorage.AccountId, settings.UserTableStorage.AccessKey, logger)
        {

        }

        public Task<Invitation> GetInvitationAsync(string id)
        {
            return base.GetAsync(id);
        }

        public async Task<Invitation> GetInviteByOrgIdAndEmailAsync(string organizationId, string email)
        {
            return (await GetByFilterAsync(
                 FilterOptions.Create("Email", FilterOptions.Operators.Equals, email.ToUpper()),
                 FilterOptions.Create("OrganizationId", FilterOptions.Operators.Equals, organizationId)
                 )).FirstOrDefault();
        }

        public Task InsertInvitationAsync(Invitation invitation)
        {
            invitation.Email = invitation.Email.ToUpper();
            return base.InsertAsync(invitation);
        }

        public Task UpdateInvitationAsync(Invitation invitation)
        {
            return base.UpdateAsync(invitation);
        }
    }
}
