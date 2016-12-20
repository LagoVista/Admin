using LagoVista.Core.Attributes;
using LagoVista.Core.Geo;
using LagoVista.UserManagement.Models.Orgs;
using LagoVista.Core.Validation;
using System;
using LagoVista.UserManagement.Models;
using LagoVista.UserManagement.Resources;

namespace LagoVista.UserManagement.ViewModels.Organization
{
    [EntityDescription(Domains.OrganizationViewModels, UserManagementResources.Names.LocationVM_Title, UserManagementResources.Names.LocationVM_Help, UserManagementResources.Names.LocationAccount_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]
    public class LocationViewModel : IValidateable
    {
        [FormField(LabelResource: Resources.UserManagementResources.Names.Location_LocationName, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public String LocationName { get; set; }

        /// <summary>
        /// Latitude and longitude for this location
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Location_GeoLocation, FieldType: FieldTypes.GeoLocation, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public IGeoLocation GeoLocation { get; set; }

        /// <summary>
        /// Primary Address
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Location_Address1, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public String Addr1 { get; set; }

        /// <summary>
        /// Secondary Address
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Location_Address2, ResourceType: typeof(Resources.UserManagementResources))]
        public String Addr2 { get; set; }
        /// <summary>
        /// City for this location
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Location_City, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public String City { get; set; }
        /// <summary>
        /// State or province for this location
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Location_State, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public String StateProvince { get; set; }
        /// <summary>
        /// Postal code for this location
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Location_PostalCode, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public String PostalCode { get; set; }
        /// <summary>
        /// Country for this location
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Location_Country, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public String Country { get; set; }

        /// <summary>
        /// A description that can be added to this location
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(Resources.UserManagementResources))]
        public String Description { get; set; }
        /// <summary>
        /// Notes that can be added to this location
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Notes, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(Resources.UserManagementResources))]
        public String Notes { get; set; }

        public virtual void MapToOrganizationLocation(OrganizationLocation location)
        {
            location.Name = LocationName;
            location.Addr1 = Addr1;
            location.Addr2 = Addr2;
            location.City = City;
            location.StateProvince = StateProvince;
            location.PostalCode = PostalCode;
            location.Country = Country;
            location.Notes = Notes;
            location.Description = Description;
        }
    }
}
