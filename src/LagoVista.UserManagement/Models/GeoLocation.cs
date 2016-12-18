using LagoVista.Core.Attributes;
using LagoVista.Core.Geo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.Models
{
    [EntityDescription(Name:"Geo Location", Domain:Domains.MiscDomain, Description:"The Geo Location Model is used to provide a class that will store latitude, longitude")]
    public class GeoLocation : IGeoLocation
    {
        public double Altitude { get; set; }

        public string LastUpdated { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
