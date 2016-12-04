using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace LagoVista.UserManagement.Models.Orgs
{
    public class Invitation : TableStorageEntity, IValidateable
    {
        public enum StatusTypes
        {
            New,
            Sent,
            Accepted,
            Declined,
            Revoked,
            Replaced
        }

        public String LinkId { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_EmailAddress, IsRequired: true, FieldType: FieldTypes.Email, ResourceType: typeof(Resources.UserManagementResources))]
        public String Email { get; set; }
        [FormField(LabelResource: Resources.UserManagementResources.Names.InviteUser_Name, IsRequired: true, FieldType: FieldTypes.Text, ResourceType: typeof(Resources.UserManagementResources))]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.InviteUser_InvitedByName, IsRequired: true, FieldType: FieldTypes.Text, ResourceType: typeof(Resources.UserManagementResources))]
        public String InvitedByName { get; set; }
        [FormField(LabelResource: Resources.UserManagementResources.Names.InviteUser_InvitedById, IsRequired: true, FieldType: FieldTypes.RowId, ResourceType: typeof(Resources.UserManagementResources))]
        public String InvitedById { get; set; }


        [FormField(LabelResource: Resources.UserManagementResources.Names.Organization_Name, IsRequired: true, FieldType: FieldTypes.Text, ResourceType: typeof(Resources.UserManagementResources))]
        public String OrganizationName { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Id, IsRequired: true, FieldType: FieldTypes.RowId, ResourceType: typeof(Resources.UserManagementResources))]
        public String OrganizationId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [FormField(LabelResource: Resources.UserManagementResources.Names.InviteUser_Status, IsRequired: true, FieldType: FieldTypes.JsonDateTime, ResourceType: typeof(Resources.UserManagementResources))]
        public StatusTypes Status { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Id, IsRequired: true, FieldType: FieldTypes.JsonDateTime, ResourceType: typeof(Resources.UserManagementResources))]
        public String DateSent { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Id, FieldType: FieldTypes.JsonDateTime, ResourceType: typeof(Resources.UserManagementResources))]
        public String DateAccepted { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Id, FieldType: FieldTypes.CheckBox, ResourceType: typeof(Resources.UserManagementResources))]
        public bool Accepted { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Id, FieldType: FieldTypes.CheckBox, ResourceType: typeof(Resources.UserManagementResources))]
        public bool Declined { get; set; }

    }
}
