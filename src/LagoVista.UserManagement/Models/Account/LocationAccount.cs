﻿using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.UserManagement.Resources;
using System;

namespace LagoVista.UserManagement.Models.Account
{
    [EntityDescription(Domains.UserDomain, UserManagementResources.Names.LocationAccount_Title, UserManagementResources.Names.LocationAccount_Help, UserManagementResources.Names.LocationAccount_Description, EntityDescriptionAttribute.EntityTypes.Dto, typeof(UserManagementResources))]
    public class LocationAccount : TableStorageEntity, IValidateable, ITableStorageAuditableEntity
    {
        /* Id will becomposed o */

        public LocationAccount(string organizationId, string locationId, string accountId)
        {
            RowKey = CreateRowId(locationId, accountId);
            PartitionKey = $"{organizationId}";
            AccountId = accountId;
            LocationId = locationId;
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
        public String LocationId { get; set; }
        [FormField(IsRequired: true)]
        public String LocationName { get; set; }
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

        public static string CreateRowId(String locationId, String accountId)
        {
            return "{locationId}.{accountId}";
        }
    }
}
