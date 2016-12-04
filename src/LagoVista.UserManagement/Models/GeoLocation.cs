using LagoVista.Core.Geo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.Models
{
    public class GeoLocation : IGeoLocation
    {
        public double Altitude { get; set; }

        public string LastUpdated { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
