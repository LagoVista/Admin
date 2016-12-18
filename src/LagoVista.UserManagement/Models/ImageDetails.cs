using LagoVista.Core.Attributes;
using Newtonsoft.Json;
using System;

namespace LagoVista.UserManagement.Models
{
    [EntityDescription(Name: "Image Details", Domain: Domains.MiscDomain, Description: "Contains meta data necessary to display an image.")]
    public class ImageDetails
    {
        [JsonProperty("id")]
        public String Id { get; set; }
        public String ImageUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
