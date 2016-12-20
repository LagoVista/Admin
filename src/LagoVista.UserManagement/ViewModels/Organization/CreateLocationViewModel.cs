using LagoVista.Core.Attributes;
using System;
using LagoVista.UserManagement.Models.Orgs;
using LagoVista.Core.Models;
using LagoVista.UserManagement.Models;
using LagoVista.UserManagement.Resources;

namespace LagoVista.UserManagement.ViewModels.Organization
{
    [EntityDescription(Domains.OrganizationDomain, UserManagementResources.Names.CreateLocationVM_Title, UserManagementResources.Names.CreateOrganizationVM_Help, UserManagementResources.Names.CreateOrganizationVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]
    public class CreateLocationViewModel : LocationViewModel
    {
        [FormField(FieldType: FieldTypes.Hidden)]
        public String OrganizationId { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Namespce, HelpResource: Resources.UserManagementResources.Names.LocationNamespace_Help, NamespaceType: NamespaceTypes.Location, NamespaceUniqueMessageResource: Resources.UserManagementResources.Names.OrganizationLocation_NamespaceInUse, FieldType: FieldTypes.NameSpace, IsRequired: true, ResourceType: typeof(Resources.UserManagementResources))]
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
            location.Namespace = LocationNamespace;
            location.AdminContact = EntityHeader.Create(AdminContactId, AdminContact);
            location.TechnicalContact = EntityHeader.Create(AdminContactId, TechnicalContact);
        }

        public static CreateLocationViewModel CreateNew(EntityHeader org, EntityHeader user)
        {
            return new CreateLocationViewModel()
            {
                OrganizationId = org.Id,
                AdminContact = user.Text,
                AdminContactId = user.Id,
                TechnicalContact = user.Text,
                TechnicalContactId = user.Id,
            };
        }
    }
}

