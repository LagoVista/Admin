using LagoVista.Core.Attributes;
using System;
using LagoVista.UserManagement.Models.Orgs;
using LagoVista.Core.Models;
using LagoVista.UserManagement.Models;
using LagoVista.UserManagement.Resources;

namespace LagoVista.UserManagement.ViewModels.Organization
{
    [EntityDescription(Domains.OrganizationViewModels, UserManagementResources.Names.UpdateLocationVM_Title, UserManagementResources.Names.UpdateLocationVM_Help, UserManagementResources.Names.UpdateLocatoinVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]
    public class UpdateLocationViewModel : LocationViewModel
    {
        [FormField(FieldType: FieldTypes.Hidden)]
        public String LocationId { get; set; }
  
        public String LastUpdatedDate { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Namespce, HelpResource: Resources.UserManagementResources.Names.LocationNamespace_Help, IsUserEditable:false, NamespaceType: NamespaceTypes.Location, NamespaceUniqueMessageResource: Resources.UserManagementResources.Names.OrganizationLocation_NamespaceInUse, FieldType: FieldTypes.NameSpace, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
        public String LocationNamespace { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.Admin_Contact, FieldType: FieldTypes.Picker, PickerType: Constants.PeoplePicker, PickerFor: nameof(AdminContactId), ResourceType: typeof(Resources.UserManagementResources))]
        public String AdminContact { get; set; }
        [FormField(IsRequired: true, FieldType: FieldTypes.Hidden)]
        public String AdminContactId { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.Technical_Contact, FieldType: FieldTypes.Picker, PickerType: Constants.PeoplePicker, PickerFor: nameof(TechnicalContactId), ResourceType: typeof(Resources.UserManagementResources))]
        public String TechnicalContact { get; set; }
        [FormField(IsRequired: true, FieldType: FieldTypes.Hidden)]
        public String TechnicalContactId { get; set; }
       
        public override void MapToOrganizationLocation(OrganizationLocation location)
        {
            base.MapToOrganizationLocation(location);
            location.AdminContact = EntityHeader.Create(AdminContactId, AdminContact);
            location.TechnicalContact = EntityHeader.Create(AdminContactId, TechnicalContact);
        }

        public static UpdateLocationViewModel CreateForOrganizationLocation(OrganizationLocation loc)
        {
            return new Organization.UpdateLocationViewModel()
            {
                LocationId = loc.Id,
                LastUpdatedDate = loc.LastUpdatedDate,
                Addr1 = loc.Addr1,
                Addr2 = loc.Addr2,
                City = loc.City,
                StateProvince = loc.StateProvince,
                Country = loc.Country,
                AdminContact = loc.AdminContact.Text,
                AdminContactId = loc.AdminContact.Id,
                TechnicalContact = loc.TechnicalContact.Text,
                TechnicalContactId = loc.TechnicalContact.Id
            };
        }
    }
}
