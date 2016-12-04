using LagoVista.UserManagement.Models.Orgs;
using System;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.Interfaces.Repos.Orgs
{
    public interface IInviteUserRepo
    {
        Task InsertInvitationAsync(Invitation invitation);
        Task UpdateInvitationAsync(Invitation invitation);
        Task<Invitation> GetInvitationAsync(String invitation);
        Task<Invitation> GetInviteByOrgIdAndEmailAsync(String orgId, String email);
    }
}
