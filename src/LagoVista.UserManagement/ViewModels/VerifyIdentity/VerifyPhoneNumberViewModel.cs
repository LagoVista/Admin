using LagoVista.Core.Attributes;
using LagoVista.Core.Validation;

namespace LagoVista.UserManagement.ViewModels.VerifyIdentity
{
    public class VerifyPhoneNumberViewModel : IValidateable
    {
        [FormField(FieldType: FieldTypes.Decimal, LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_PhoneVerificationCode, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string Code { get; set; }

        [FormField(IsRequired: true, LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_PhoneNumber, FieldType: FieldTypes.Phone, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string PhoneNumber { get; set; }
    }
}
