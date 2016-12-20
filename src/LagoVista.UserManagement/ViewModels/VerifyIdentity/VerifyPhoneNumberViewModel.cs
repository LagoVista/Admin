using LagoVista.Core.Attributes;
using LagoVista.Core.Validation;
using LagoVista.UserManagement.Models;
using LagoVista.UserManagement.Resources;

namespace LagoVista.UserManagement.ViewModels.VerifyIdentity
{
    [EntityDescription(Domains.SecurityViewModels, UserManagementResources.Names.VerifyPhoneNumberVM_Title, UserManagementResources.Names.VerifyPhoneNumberVM_Help, UserManagementResources.Names.VerifyPhoneNumberVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]

    public class VerifyPhoneNumberViewModel : IValidateable
    {
        [FormField(FieldType: FieldTypes.Decimal, LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_PhoneVerificationCode, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string Code { get; set; }

        [FormField(IsRequired: true, LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_PhoneNumber, FieldType: FieldTypes.Phone, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string PhoneNumber { get; set; }
    }
}
