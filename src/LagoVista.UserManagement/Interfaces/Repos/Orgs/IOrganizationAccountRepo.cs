using System.Collections.Generic;
using System.Threading.Tasks;
using LagoVista.UserManagement.Models;
using LagoVista.UserManagement.Models.Orgs;
using LagoVista.UserManagement.Models.Account;
using LagoVista.Core.Models;

namespace LagoVista.UserManagement.Interfaces.Repos.Orgs
{
    public interface IOrganizationAccountRepo
    {
        Task<OrganizationAccount> AddAccountUserAsync(OrganizationAccount accountUser);
        Task<IEnumerable<OrganizationAccount>> GetOrganizationsForAccountAsync(string accountId);
        Task<IEnumerable<OrganizationAccount>> GetAccountsForOrganizationAsync(string organizationId);
        Task RemoveAccountFromOrgAsync(EntityHeader account, EntityHeader org, EntityHeader removedBy);
        Task<bool> QueryOrganizationHasAccountAsync(string organizationId, string accountId);
        Task<bool> QueryOrganizationHasAccountByEmailAsync(string organizationId, string email);
    }
}