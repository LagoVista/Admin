using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.Models.Security
{
    [EntityDescription(Name: "Location Account Roles", Domain: Domains.SecurityDomain, Description: "In some caes, user have different roles depending on which location they are working in.  This entity manages those roles.")]
    public class LocationAccountRoles : TableStorageEntity
    {
        public EntityHeader Location { get; set; }
        public EntityHeader Account { get; set; }
        public EntityHeader Role { get; set; }
    }
}
