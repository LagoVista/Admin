using LagoVista.Core.Attributes;
using LagoVista.Core.Validation;

namespace LagoVista.UserManagement.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel : IValidateable
    {
        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_Email, FieldType: FieldTypes.Email, IsRequired: true, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string Email { get; set; }
    }
}
