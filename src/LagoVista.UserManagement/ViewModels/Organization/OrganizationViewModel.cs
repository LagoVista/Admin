using LagoVista.Core.Attributes;
using LagoVista.UserManagement.Models;
using LagoVista.UserManagement.Resources;
using System;

namespace LagoVista.UserManagement.ViewModels.Organization
{
    [EntityDescription(Domains.OrganizationViewModels, UserManagementResources.Names.OrganizationVM_Title, UserManagementResources.Names.OrganizationVM_Help, UserManagementResources.Names.OrganizationVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]
    public class OrganizationViewModel
    {
        [FormField(LabelResource: Resources.UserManagementResources.Names.Organization_Name, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public string Name { get; set; }
        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Namespce, IsUserEditable: false, FieldType: FieldTypes.NameSpace, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public string Namespace { get; set; }
        [FormField(LabelResource: Resources.UserManagementResources.Names.Organization_WebSite, ResourceType: typeof(Resources.UserManagementResources))]
        public String WebSite { get; set; }

    }
}
