using LagoVista.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.ViewModels.Organization
{
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
