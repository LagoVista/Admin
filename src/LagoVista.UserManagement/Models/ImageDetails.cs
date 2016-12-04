using Newtonsoft.Json;
using System;

namespace LagoVista.UserManagement.Models
{
    public class ImageDetails
    {
        [JsonProperty("id")]
        public String Id { get; set; }
        public String ImageUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
