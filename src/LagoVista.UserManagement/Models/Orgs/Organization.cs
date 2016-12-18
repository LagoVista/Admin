﻿using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using System;
using System.Collections.Generic;

namespace LagoVista.UserManagement.Models.Orgs
{
    [EntityDescription(Name: "Organization", Domain: Domains.OrganizationDomain, Description: "An organization is a container that can be used to group user, locations, devices, device configurations and any other data or functionalality.")]
    public class Organization : UserManagementBase, INamedEntity, IValidateable
    {
        public Organization()
        {
            Locations = new List<EntityHeader>();
        }

        [FormField(LabelResource:Resources.UserManagementResources.Names.Organization_Name, IsRequired:true,ResourceType:typeof(Resources.UserManagementResources))]
        public string Name { get; set; }
        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Namespce, NamespaceType: NamespaceTypes.Organization, NamespaceUniqueMessageResource: Resources.UserManagementResources.Names.Organization_NamespaceInUse, FieldType:FieldTypes.NameSpace, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public string Namespace { get; set; }
        [FormField(LabelResource: Resources.UserManagementResources.Names.Organization_WebSite, ResourceType: typeof(Resources.UserManagementResources))]
        public String WebSite { get; set; }
        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Status, IsUserEditable:false, ResourceType: typeof(Resources.UserManagementResources))]
        public String Status { get; set; }
        [FormField(LabelResource: Resources.UserManagementResources.Names.Organization_Primary_Location, IsRequired: true, IsUserEditable: false, ResourceType: typeof(Resources.UserManagementResources))]
        public EntityHeader PrimaryLocation { get; set; }
        [FormField(LabelResource: Resources.UserManagementResources.Names.Admin_Contact, IsRequired:true, ResourceType: typeof(Resources.UserManagementResources))]
        public EntityHeader AdminContact { get; set; }
        [FormField(LabelResource: Resources.UserManagementResources.Names.Billing_Contact, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public EntityHeader BillingContact { get; set; }
        [FormField(LabelResource: Resources.UserManagementResources.Names.Technical_Contact, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public EntityHeader TechnicalContact { get; set; }
        [FormField(LabelResource: Resources.UserManagementResources.Names.Organization_Locations, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public List<EntityHeader> Locations { get; set; }

        public EntityHeader ToEntityHeader()
        {
            return new EntityHeader()
            {
                Id = Id,
                Text = Name,
            };
        }

        public override string ToString()
        {
            return Namespace;
        }

    }
}
