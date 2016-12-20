
using LagoVista.Core.Attributes;
using LagoVista.Core.Validation;
using LagoVista.UserManagement.Models;
using LagoVista.UserManagement.Resources;

namespace LagoVista.UserManagement.ViewModels.Account
{
    [EntityDescription(Domains.SecurityDomain, UserManagementResources.Names.VerifyCodeVM_Title, UserManagementResources.Names.VerifyCodeVM_Help, UserManagementResources.Names.VerifyCodeVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]
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
