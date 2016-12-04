using LagoVista.Core.Attributes;
using LagoVista.UserManagement.Resources;
using LagoVista.Core.Validation;

namespace LagoVista.UserManagement.ViewModels.ManageAccount
{
    public class SetPasswordViewModel : IValidateable
    {       
        [FormField(LabelResource: UserManagementResources.Names.AppUser_Password, FieldType: FieldTypes.Password, IsRequired: true, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string NewPassword { get; set; }

        [FormField(LabelResource: UserManagementResources.Names.AppUser_ConfirmPassword, CompareTo: nameof(NewPassword), CompareToMsgResource: UserManagementResources.Names.AppUser_PasswordConfirmPasswordMatch, FieldType: FieldTypes.Password, IsRequired: true, ResourceType: typeof(UserManagementResources))]
        public string ConfirmPassword { get; set; }
    }
}
