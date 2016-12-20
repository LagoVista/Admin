using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.UserManagement.Resources;

namespace LagoVista.UserManagement.Models.Security
{
    [EntityDescription(Domains.SecurityDomain, UserManagementResources.Names.LocationAccountRole_Title, UserManagementResources.Names.LocationAccountRole_Help, UserManagementResources.Names.LocationAccountRole_Description, EntityDescriptionAttribute.EntityTypes.Dto, typeof(UserManagementResources))]
    public class LocationAccountRoles : TableStorageEntity
    {
        public EntityHeader Location { get; set; }
        public EntityHeader Account { get; set; }
        public EntityHeader Role { get; set; }
    }
}
