using LagoVista.Core.Attributes;
using LagoVista.UserManagement.Resources;
using Newtonsoft.Json;
using System;

namespace LagoVista.UserManagement.Models
{
    [EntityDescription(Domains.MiscDomain, UserManagementResources.Names.ImageDetails_Title, UserManagementResources.Names.ImageDetails_Description, UserManagementResources.Names.LocationAccountRole_Description, EntityDescriptionAttribute.EntityTypes.Dto, typeof(UserManagementResources))]
    public class ImageDetails
    {
        [JsonProperty("id")]
        public String Id { get; set; }
        public String ImageUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
