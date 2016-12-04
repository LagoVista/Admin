using LagoVista.Core.Attributes;

namespace LagoVista.UserManagement.ViewModels.ManageAccount
{
    public class IndexViewModel
    {
        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.VerifyUser_PhoneConfirmed, FieldType: FieldTypes.Phone, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public string PhoneNumber { get; set; }

        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.VerifyUser_BrowserRemembered, FieldType: FieldTypes.Bool, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public bool BrowserRemembered { get; set; }

        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.VerifyUser_EmailConfirmed, FieldType: FieldTypes.Bool, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public bool EmailConfirmed { get; set; }

        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.VerifyUser_PhoneConfirmed, FieldType: FieldTypes.Bool, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources))]
        public bool PhoneConfirmd { get; set; }
    }
}
