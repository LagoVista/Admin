using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.Models.Security
{
    [EntityDescription(Name: "Organization Account Roles", Domain: Domains.SecurityDomain, Description: "The Organization Account Roles Structures defines which roles the user hold in a particular organization.")]
    public class OrganizationAccountRoles : TableStorageEntity
    {
        public EntityHeader Location { get; set; }
        public EntityHeader Account { get; set; }
        public EntityHeader Role { get; set; }
    }
}
