using LagoVista.UserManagement.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.Interfaces.Repos.Security
{
    public interface IRoleRepo : IDisposable
    {
        Task AddRoleAsync(String organizationId, Role role);
        Task InsertAsync(Role role);

        Task RemoveAsync(string id, string etag = "*");

        Task<Role> GetAsync(string id);

        Task UpdateAsync(Role role);
    }
}
