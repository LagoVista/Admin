using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.UserManagement.Resources;
using System;

namespace LagoVista.UserManagement.Models.Account
{
    [EntityDescription(Domains.UserDomain, UserManagementResources.Names.Role_Title, UserManagementResources.Names.Role_Help, UserManagementResources.Names.Role_Description, EntityDescriptionAttribute.EntityTypes.Dto, typeof(UserManagementResources))]
    public class Role : UserManagementBase, INamedEntity
    {
        public String Name { get; set; }
        public String OrganizationName { get; set; }
    }
}
