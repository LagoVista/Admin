using System.Threading.Tasks;
using LagoVista.UserManagement.Models;
using LagoVista.UserManagement.Models.Orgs;

namespace LagoVista.UserManagement.Interfaces.Repos.Orgs
{
    public interface IOrganizationRepo
    {
        Task AddOrganizationAsync(Organization account);
        Task<Organization> GetOrganizationAsync(string id);
        Task UpdateOrganizationAsync(Organization account);
        Task<bool> QueryOrganizationExistAsync(string id);
        Task<bool> QueryNamespaceInUseAsync(string namespaceText);
    }
}