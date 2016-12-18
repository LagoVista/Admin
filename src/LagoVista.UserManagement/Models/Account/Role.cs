using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using System;

namespace LagoVista.UserManagement.Models.Account
{
    [EntityDescription(Name:"User Role", Domain:Domains.UserDomain, Description:"Roles are used to assigned to a user to give them access to certain functionality of the system.")]
    public class Role : UserManagementBase, INamedEntity
    {
        public String Name { get; set; }
        public String OrganizationName { get; set; }
    }
}
