using LagoVista.Core.Attributes;
using LagoVista.UserManagement.Models;
using LagoVista.UserManagement.Resources;

namespace LagoVista.UserManagement.ViewModels.Organization
{
    [EntityDescription(Domains.OrganizationViewModels, UserManagementResources.Names.InviteUserVM_Title, UserManagementResources.Names.InviteUserVM_Help, UserManagementResources.Names.InviteUserVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]
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
