using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.UserManagement.Models;
using LagoVista.UserManagement.Resources;
using System;

namespace LagoVista.UserManagement.ViewModels.Organization
{
    [EntityDescription(Domains.OrganizationViewModels, UserManagementResources.Names.UpdateOrganizationVM_Title, UserManagementResources.Names.UpdateOrganizationVM_Help, UserManagementResources.Names.UpdateOrganizationVM_Description, EntityDescriptionAttribute.EntityTypes.ViewModel, typeof(UserManagementResources))]
    public class UpdateOrganizationViewModel : OrganizationViewModel, IValidateable
    {
        [FormField(IsRequired: true, FieldType: FieldTypes.Hidden)]
        public String OrganziationId { get; set; }

        [FormField(IsRequired: true, FieldType: FieldTypes.Hidden)]
        public String LastUpdatedDate { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.Organization_Primary_Location, FieldType: FieldTypes.Picker, PickerType: Constants.LocationPicker, PickerFor: (nameof(PrimaryLocationId)), ResourceType: typeof(Resources.UserManagementResources))]
        public String PrimaryLocation { get; set; }
        [FormField(IsRequired: true, FieldType: FieldTypes.Hidden)]
        public String PrimaryLocationId { get; set; }


        [FormField(LabelResource: Resources.UserManagementResources.Names.Admin_Contact, FieldType: FieldTypes.Picker, PickerType: Constants.PeoplePicker, PickerFor: nameof(AdminContactId), ResourceType: typeof(Resources.UserManagementResources))]
        public String AdminContact { get; set; }
        [FormField(IsRequired: true, FieldType: FieldTypes.Hidden)]
        public String AdminContactId { get; set; }


        [FormField(LabelResource: Resources.UserManagementResources.Names.Billing_Contact, FieldType: FieldTypes.Picker, PickerType: Constants.PeoplePicker, PickerFor: nameof(BillingContactId), ResourceType: typeof(Resources.UserManagementResources))]
        public String BillingContact { get; set; }
        [FormField(IsRequired: true, FieldType: FieldTypes.Hidden)]
        public String BillingContactId { get; set; }


        [FormField(LabelResource: Resources.UserManagementResources.Names.Technical_Contact, FieldType: FieldTypes.Picker, PickerType: Constants.PeoplePicker, PickerFor: nameof(TechnicalContactId), ResourceType: typeof(Resources.UserManagementResources))]
        public String TechnicalContact { get; set; }
        [FormField(IsRequired: true, FieldType: FieldTypes.Hidden)]
        public String TechnicalContactId { get; set; }

        public void MapToOrganziation(Models.Orgs.Organization organization)
        {
            organization.Name = Name;
            organization.WebSite = WebSite;
            organization.PrimaryLocation = EntityHeader.Create(PrimaryLocationId, PrimaryLocation);
            organization.AdminContact = EntityHeader.Create(AdminContactId, AdminContact);
            organization.BillingContact = EntityHeader.Create(BillingContactId, BillingContact);
            organization.TechnicalContact = EntityHeader.Create(TechnicalContactId, TechnicalContact);
        }

        public static UpdateOrganizationViewModel CreateFromOrg(Models.Orgs.Organization org)
        {
            return new UpdateOrganizationViewModel()
            {
                OrganziationId = org.Id,
                LastUpdatedDate = org.LastUpdatedDate,
                Name = org.Name,
                Namespace = org.Namespace,
                WebSite = org.WebSite,
                PrimaryLocation = org.PrimaryLocation.Text,
                PrimaryLocationId = org.PrimaryLocation.Text,
                AdminContact = org.AdminContact.Text,
                AdminContactId = org.AdminContact.Id,
                BillingContact = org.BillingContact.Text,
                BillingContactId = org.BillingContact.Id,
                TechnicalContact = org.TechnicalContact.Id,
                TechnicalContactId = org.TechnicalContact.Id,
            };
        }
    }
}
