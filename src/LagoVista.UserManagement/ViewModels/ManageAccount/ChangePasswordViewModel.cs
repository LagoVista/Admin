using LagoVista.Core.Attributes;
using LagoVista.UserManagement.Resources;
using LagoVista.Core.Validation;
using LagoVista.UserManagement.Models;

namespace LagoVista.UserManagement.ViewModels.ManageAccount
{
    [EntityDescription(Domains.SecurityViewModels, UserManagementResources.Names.ChangePasswordVM_Title, UserManagementResources.Names.ChangePasswordVM_Help, UserManagementResources.Names.ChangePasswordVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]
    public class ChangePasswordViewModel : IValidateable
    {
        [FormField(LabelResource: UserManagementResources.Names.AppUser_OldPassword, FieldType: FieldTypes.Password, IsRequired: true, ResourceType: typeof(UserManagementResources))]
        public string OldPassword { get; set; }

        [FormField(LabelResource: UserManagementResources.Names.AppUser_NewPassword, FieldType: FieldTypes.Password, IsRequired: true, ResourceType: typeof(UserManagementResources))]
        public string NewPassword { get; set; }

        [FormField(LabelResource: UserManagementResources.Names.AppUser_ConfirmPassword, CompareTo: nameof(NewPassword), CompareToMsgResource: UserManagementResources.Names.AppUser_PasswordConfirmPasswordMatch, FieldType: FieldTypes.Password, IsRequired: true, ResourceType: typeof(UserManagementResources))]
        public string ConfirmPassword { get; set; }
    }
}
