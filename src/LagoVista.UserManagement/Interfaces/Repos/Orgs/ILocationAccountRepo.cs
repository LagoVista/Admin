﻿
using LagoVista.Core.Models;
using LagoVista.UserManagement.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.Interfaces.Repos.Orgs
{
    public interface ILocationAccountRepo
    {
        Task AddAccountToLocationAsync(LocationAccount locationAccount);
        Task RemoveAccountFromLocationAsync(string locationId, string accountId, EntityHeader removedBy);
        Task<IEnumerable<LocationAccount>> GetAccountsForLocationAsync(string locationId);
        Task<IEnumerable<LocationAccount>> GetLocationsForAccountAsync(string accountId);
        
    }
}
