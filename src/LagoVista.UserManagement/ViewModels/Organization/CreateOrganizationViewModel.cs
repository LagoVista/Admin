using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.UserManagement.Models.Orgs;
using LagoVista.Core.Validation;
using System;

namespace LagoVista.UserManagement.ViewModels.Organization
{
    public class CreateOrganizationViewModel : LocationViewModel, IValidateable
    {
        [FormField(LabelResource: Resources.UserManagementResources.Names.Organization_Name, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public string Name { get; set; }
        [FormField(LabelResource: Resources.UserManagementResources.Names.Organization_WebSite, ResourceType: typeof(Resources.UserManagementResources))]
        public String WebSite { get; set; }
        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Namespce, FieldType: FieldTypes.NameSpace, NamespaceType: NamespaceTypes.Organization, IsRequired: true, NamespaceUniqueMessageResource: Resources.UserManagementResources.Names.Organization_NamespaceInUse, ResourceType: typeof(Resources.UserManagementResources))]
        public String Namespace { get; set; }
        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Namespce, HelpResource: Resources.UserManagementResources.Names.LocationNamespace_Help, NamespaceType: NamespaceTypes.Location, FieldType: FieldTypes.NameSpace, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public String LocationNamespace { get; set; }

        public void MapToOrganization(LagoVista.UserManagement.Models.Orgs.Organization organization)
        {
            organization.Name = Name;
            organization.Namespace = Namespace;
            organization.WebSite = WebSite;
        }

        public override void MapToOrganizationLocation(OrganizationLocation location)
        {
            base.MapToOrganizationLocation(location);
            location.Namespace = LocationNamespace;
        }

    }
}
