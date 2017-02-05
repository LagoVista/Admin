using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.UserManagement.Resources;
using Newtonsoft.Json;
using System;

namespace LagoVista.UserManagement.Models
{
    public abstract class UserManagementBase : ModelBase, IIDEntity, IAuditableEntity, INoSQLEntity
    {
        public String EntityType { get; set; }
        public String DatabaseName { get; set; }


        [JsonProperty("id")]
        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_Id, ResourceType: typeof(Resources.UserManagementResources))]
        public String Id { get; set; }

        private String _creationDate;
        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_CreationDate, FieldType: FieldTypes.JsonDateTime, ResourceType: typeof(UserManagementResources), IsRequired: true, IsUserEditable: false)]
        public String CreationDate { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_CreatedBy, ResourceType: typeof(UserManagementResources), IsRequired: true, IsUserEditable: false)]
        public EntityHeader CreatedBy { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_LastUpdatedDate, FieldType: FieldTypes.JsonDateTime, ResourceType: typeof(UserManagementResources), IsRequired: true, IsUserEditable: false)]
        public String LastUpdatedDate { get; set; }

        [FormField(LabelResource: Resources.UserManagementResources.Names.Common_LastUpdatedBy, ResourceType: typeof(UserManagementResources), IsRequired: true, IsUserEditable: false)]
        public EntityHeader LastUpdatedBy { get; set; }
    }
}
