using LagoVista.Core.Attributes;
using LagoVista.UserManagement.Resources;
using LagoVista.Core.Validation;
using LagoVista.UserManagement.Models;

namespace LagoVista.UserManagement.ViewModels.Account
{
    [EntityDescription(Domains.SecurityViewModels, UserManagementResources.Names.ResetPassword_Title, UserManagementResources.Names.ResetPassword_Help, UserManagementResources.Names.ResetPassword_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]
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
