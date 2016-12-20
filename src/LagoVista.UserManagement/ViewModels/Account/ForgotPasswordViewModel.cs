using LagoVista.Core.Attributes;
using LagoVista.Core.Validation;
using LagoVista.UserManagement.Models;
using LagoVista.UserManagement.Resources;

namespace LagoVista.UserManagement.ViewModels.Account
{
    [EntityDescription(Domains.SecurityViewModels, UserManagementResources.Names.ForgotPasswordVM_Title, UserManagementResources.Names.ForgotPasswordVM_Help, UserManagementResources.Names.ForgotPasswordVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]

    public class ForgotPasswordViewModel : IValidateable
    {
        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_Email, FieldType: FieldTypes.Email, IsRequired: true, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string Email { get; set; }
    }
}
