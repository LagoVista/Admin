using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Geo;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using Newtonsoft.Json;
using System;

namespace LagoVista.UserManagement.Models.Orgs
{
    [EntityDescription(Name: "Organization Location Relationship", Domain: Domains.OrganizationDomain, Description: "An Organization can have Many Locations.  Locations are used to furhter organize resources.")]
    public class OrganizationLocation : UserManagementBase, INamedEntity, IValidateable
    {
        [FormField(LabelResource: Resources.UserManagementResources.Names.Organization, IsRequired:true, ResourceType: typeof(Resources.UserManagementResources))]
        public EntityHeader Organization { get; set; }

        /// <summary>
        /// Name space to be used for any devices at this location.  It will build upon the accounts name space.
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Namespce, NamespaceType: NamespaceTypes.Location, NamespaceUniqueMessageResource: Resources.UserManagementResources.Names.OrganizationLocation_NamespaceInUse, FieldType: FieldTypes.NameSpace, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public String Namespace { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.Location_LocationName, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public String Name { get; set; }
       
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
        [FormField(LabelResource: Resources.UserManagementResources.Names.Location_City, ResourceType: typeof(Resources.UserManagementResources))]
        public String City { get; set; }
        /// <summary>
        /// State or province for this location
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Location_State, ResourceType: typeof(Resources.UserManagementResources))]
        public String StateProvince { get; set; }
        /// <summary>
        /// Postal code for this location
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Location_PostalCode,  ResourceType: typeof(Resources.UserManagementResources))]
        public String PostalCode { get; set; }

        /// <summary>
        /// Country for this location
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Location_Country, ResourceType: typeof(Resources.UserManagementResources))]
        public String Country { get; set; }

        /// <summary>
        /// Main Contact for this Location
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Admin_Contact, IsRequired: true,  ResourceType: typeof(Resources.UserManagementResources))]
        public EntityHeader AdminContact { get; set; }

        /// <summary>
        /// The technical contact for this location.
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Technical_Contact, IsRequired: true,  ResourceType: typeof(Resources.UserManagementResources))]
        public EntityHeader TechnicalContact { get; set; }


        /// <summary>
        /// A description that can be added to this location
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Description, FieldType:FieldTypes.MultiLineText, ResourceType: typeof(Resources.UserManagementResources))]
        public String Description { get; set; }
        /// <summary>
        /// Notes that can be added to this location
        /// </summary>
        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Notes, FieldType:FieldTypes.MultiLineText, ResourceType: typeof(Resources.UserManagementResources))]
        public String Notes { get; set; }

        public EntityHeader ToEntityHeader()
        {
            return EntityHeader.Create(Id, Name);
         
        }

        public override string ToString()
        {
            return Namespace;
        }
    }
}
