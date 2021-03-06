﻿using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.UserManagement.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.Managers
{
    public interface IAppUserManager
    {
        Task<AppUser> GetUserByIdAsync(String id, EntityHeader requestedByUser);

        Task<InvokeResult> UpdateUserAsync(AppUser user, EntityHeader updatedByUser);

        Task<InvokeResult> AddUserAsync(AppUser user, EntityHeader org, EntityHeader updatedByUserId);

        Task<InvokeResult> DeleteUserAsync(String id, EntityHeader deletedByUser);

        Task<IEnumerable<EntityHeader>> SearchUsers(string firstName, string lastName, EntityHeader searchedBy);
    }
}
