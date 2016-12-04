using LagoVista.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.ViewModels.Organization
{
    public class InviteUserViewModel
    {
        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.Common_EmailAddress, FieldType: FieldTypes.Email, IsRequired: true, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string Email { get; set; }

        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.InviteUser_Name,  IsRequired: true, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string Name { get; set; }

        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.InviteUser_Greeting_Label, FieldType: FieldTypes.MultiLineText, IsRequired: true, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string Message { get; set; }

    }
}
