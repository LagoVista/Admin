using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.ViewModels.Organization
{
    public class OrganizationDetailsViewModel
    {
        public String OrganizationName { get; set; }
        public Models.Orgs.Organization Organization { get; set; }
        public IEnumerable<Models.Orgs.OrganizationAccount> People { get; set; }
        public IEnumerable<Models.Orgs.OrganizationLocation> Locations { get; set; }
    }
}
