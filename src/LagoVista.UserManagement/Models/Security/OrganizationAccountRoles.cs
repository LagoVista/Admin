using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.UserManagement.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.Models.Security
{
    [EntityDescription(Domains.SecurityDomain, UserManagementResources.Names.OrganizationAccountRole_Title, UserManagementResources.Names.OrganizationAccountRole_Title, UserManagementResources.Names.OrganizationAccountRole_Description, EntityDescriptionAttribute.EntityTypes.Dto, typeof(UserManagementResources))]
    public class OrganizationAccountRoles : TableStorageEntity
    {
        public EntityHeader Location { get; set; }
        public EntityHeader Account { get; set; }
        public EntityHeader Role { get; set; }
    }
}
