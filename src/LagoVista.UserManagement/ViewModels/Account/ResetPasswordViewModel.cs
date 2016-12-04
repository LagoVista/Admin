using LagoVista.Core.Attributes;
using LagoVista.UserManagement.Resources;
using LagoVista.Core.Validation;

namespace LagoVista.UserManagement.ViewModels.Account
{
    public class ResetPasswordViewModel : IValidateable
    {
        [FormField(LabelResource: UserManagementResources.Names.AppUser_Email, FieldType: FieldTypes.Email, IsRequired: true, ResourceType: typeof(UserManagementResources))]
        public string Email { get; set; }

        [FormField(LabelResource: UserManagementResources.Names.AppUser_Password, FieldType: FieldTypes.Password, IsRequired: true, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string Password { get; set; }

        [FormField(LabelResource: UserManagementResources.Names.AppUser_ConfirmPassword, CompareTo: nameof(Password), CompareToMsgResource: UserManagementResources.Names.AppUser_PasswordConfirmPasswordMatch, FieldType: FieldTypes.Password, IsRequired: true, ResourceType: typeof(UserManagementResources))]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
