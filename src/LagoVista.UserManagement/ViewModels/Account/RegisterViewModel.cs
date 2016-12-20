using LagoVista.Core.Attributes;
using System;
using LagoVista.UserManagement.Resources;
using LagoVista.Core.Validation;
using LagoVista.UserManagement.Models;

namespace LagoVista.UserManagement.ViewModels.Account
{
    [EntityDescription(Domains.UserViewModels, UserManagementResources.Names.RegisterVM_Title, UserManagementResources.Names.RegisterVM_Help, UserManagementResources.Names.RegisterVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]
    public class RegisterViewModel : IValidateable
    {
        [FormField(LabelResource: UserManagementResources.Names.AppUser_FirstName, FieldType: FieldTypes.Text, IsRequired: true, ResourceType: typeof(UserManagementResources))]
        public String FirstName { get; set; }

        [FormField(LabelResource: UserManagementResources.Names.AppUser_LastName, FieldType: FieldTypes.Text, IsRequired: true, ResourceType: typeof(UserManagementResources))]
        public String LastName { get; set; }

        [FormField(LabelResource: UserManagementResources.Names.AppUser_Email, FieldType: FieldTypes.Email, IsRequired: true, ResourceType: typeof(UserManagementResources))]
        public String Email { get; set; }

        [FormField(LabelResource: UserManagementResources.Names.AppUser_Password, FieldType: FieldTypes.Password, IsRequired: true, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string Password { get; set; }

        [FormField(LabelResource: UserManagementResources.Names.AppUser_ConfirmPassword, CompareTo: nameof(Password), CompareToMsgResource: UserManagementResources.Names.AppUser_PasswordConfirmPasswordMatch, FieldType: FieldTypes.Password, IsRequired: true, ResourceType: typeof(UserManagementResources))]
        public string ConfirmPassword { get; set; }
    }
}
