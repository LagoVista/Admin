using LagoVista.Core.Attributes;
using LagoVista.UserManagement.Models;
using LagoVista.UserManagement.Resources;
using System.Collections.Generic;


namespace LagoVista.UserManagement.ViewModels.Account
{
    [EntityDescription(Domains.SecurityViewModels, UserManagementResources.Names.SendCodeVM_Title, UserManagementResources.Names.SetPasswordVM_Help, UserManagementResources.Names.SendCodeVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]
    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}
