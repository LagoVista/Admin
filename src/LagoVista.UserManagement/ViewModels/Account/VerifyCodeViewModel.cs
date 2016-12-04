
using LagoVista.Core.Attributes;
using LagoVista.Core.Validation;

namespace LagoVista.UserManagement.ViewModels.Account
{
    public class VerifyCodeViewModel : IValidateable
    {
        [FormField(IsRequired: true)]
        public string Provider { get; set; }

        [FormField(IsRequired:true, FieldType:FieldTypes.Integer)]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }

        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_RememberMe, FieldType: FieldTypes.CheckBox, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public bool RememberBrowser { get; set; }

        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.AppUser_RememberMe, FieldType: FieldTypes.CheckBox, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public bool RememberMe { get; set; }
    }
}
