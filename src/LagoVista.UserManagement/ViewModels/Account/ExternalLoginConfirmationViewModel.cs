using LagoVista.Core.Attributes;
using LagoVista.Core.Validation;
using LagoVista.UserManagement.Models;
using LagoVista.UserManagement.Resources;

namespace LagoVista.UserManagement.ViewModels.Account
{
    [EntityDescription(Domains.SecurityViewModels, UserManagementResources.Names.ExternalLoginConfirmVM_Title, UserManagementResources.Names.ExternalLoginConfirmVM_Help, UserManagementResources.Names.ExternalLoginConfirmVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]
    public class ExternalLoginConfirmationViewModel : IValidateable
    {
        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_Email, FieldType: FieldTypes.Email, IsRequired: true, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string Email { get; set; }
    }
}
