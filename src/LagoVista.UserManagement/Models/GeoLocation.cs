using LagoVista.Core.Attributes;
using LagoVista.Core.Geo;
using LagoVista.UserManagement.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.Models
{
    [EntityDescription(Domains.MiscDomain, UserManagementResources.Names.GeoLocation_Title, UserManagementResources.Names.GeoLocation_Help, UserManagementResources.Names.GeoLocation_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(UserManagementResources))]
    public class GeoLocation : IGeoLocation
    {
        public double Altitude { get; set; }

        public string LastUpdated { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
