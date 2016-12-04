using LagoVista.Core.Attributes;
using LagoVista.Core.Validation;


namespace LagoVista.UserManagement.ViewModels.Account
{
    public class LoginViewModel : IValidateable
    {
        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_Email, FieldType: FieldTypes.Email, IsRequired: true, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string Email { get; set; }

        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_Password, FieldType: FieldTypes.Password, IsRequired: true, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string Password { get; set; }

        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_RememberMe, FieldType: FieldTypes.CheckBox,  ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public bool RememberMe { get; set; }
    }
}
