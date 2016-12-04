using LagoVista.UserManagement.Models.Orgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.Interfaces.Managers
{
    public interface ILocationManager
    {
        Task AddLocationAsync(OrganizationLocation location);

        Task UpdateLocationAsync(OrganizationLocation location);

        Task<OrganizationLocation> GetLocationAsync(String locationId);
    }
}
