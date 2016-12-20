using LagoVista.Core.Attributes;
using LagoVista.UserManagement.Models;
using LagoVista.UserManagement.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.ViewModels.Organization
{
    [EntityDescription(Domains.OrganizationViewModels, UserManagementResources.Names.OrganizationDetailVM_Title, UserManagementResources.Names.OrganizationDetailVM_Help, UserManagementResources.Names.OrganizationDetailsVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]
    public class OrganizationDetailsViewModel
    {
        public String OrganizationName { get; set; }
        public Models.Orgs.Organization Organization { get; set; }
        public IEnumerable<Models.Orgs.OrganizationAccount> People { get; set; }
        public IEnumerable<Models.Orgs.OrganizationLocation> Locations { get; set; }
    }
}
