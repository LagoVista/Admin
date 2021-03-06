﻿using LagoVista.Core.Attributes;
using LagoVista.UserManagement.Resources;
using LagoVista.Core.Validation;
using LagoVista.UserManagement.Models;

namespace LagoVista.UserManagement.ViewModels.ManageAccount
{
    [EntityDescription(Domains.SecurityViewModels, UserManagementResources.Names.SetPasswordVM_Title, UserManagementResources.Names.SetPasswordVM_Help, UserManagementResources.Names.SetPasswordVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]
    public class SetPasswordViewModel : IValidateable
    {       
        [FormField(LabelResource: UserManagementResources.Names.AppUser_Password, FieldType: FieldTypes.Password, IsRequired: true, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string NewPassword { get; set; }

        [FormField(LabelResource: UserManagementResources.Names.AppUser_ConfirmPassword, CompareTo: nameof(NewPassword), CompareToMsgResource: UserManagementResources.Names.AppUser_PasswordConfirmPasswordMatch, FieldType: FieldTypes.Password, IsRequired: true, ResourceType: typeof(UserManagementResources))]
        public string ConfirmPassword { get; set; }
    }
}
