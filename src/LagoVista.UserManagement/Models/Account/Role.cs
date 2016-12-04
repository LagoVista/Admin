using LagoVista.Core.Interfaces;
using System;

namespace LagoVista.UserManagement.Models.Account
{
    public class Role : UserManagementBase, INamedEntity
    {
        public String Name { get; set; }
        public String OrganizationName { get; set; }
    }
}
