using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using System;

namespace LagoVista.UserManagement.Models.Orgs
{
    [EntityDescription(Name: "Organization Account Relationship", Domain: Domains.OrganizationDomain, Description: "The Organization Account Relationship table is used to map accounts to an organization.")]
    public class OrganizationAccount : TableStorageEntity, IValidateable, ITableStorageAuditableEntity
    {
        /* Id will becomposed o */

        public OrganizationAccount(string organizationId, string accountId)
        {
            RowKey = CreateRowKey(organizationId, accountId);
            PartitionKey = $"{organizationId}";
            AccountId = accountId;
            OrganizationId = organizationId;
        }

        [FormField(IsRequired: true)]
        public String AccountId { get; set; }
        [FormField(IsRequired: true)]
        public String AccountName { get; set; }
        [FormField(IsRequired: true)]
        public String OrganizationId { get; set; }
        [FormField(IsRequired: true)]
        public String OrganizationName { get; set; }
        [FormField(IsRequired: true)]
        public String ProfileImageUrl { get; set; }
        [FormField(IsRequired: true)]
        public String Email { get; set; }
        [FormField(IsRequired: true)]
        public String CreatedBy { get; set; }
        [FormField(IsRequired: true)]
        public String CreatedById { get; set; }
        [FormField(IsRequired: true)]
        public String CreationDate { get; set; }
        [FormField(IsRequired: true)]
        public String LastUpdatedBy { get; set; }
        [FormField(IsRequired: true)]
        public String LastUpdatedById { get; set; }
        [FormField(IsRequired: true)]
        public String LastUpdatedDate { get; set; }

        public static String CreateRowKey(String organizationId, String accountId)
        {
            return $"{organizationId}.{accountId}";
        }
    }
}
