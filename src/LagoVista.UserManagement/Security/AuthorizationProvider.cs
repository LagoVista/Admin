using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.UserManagement.Security
{
    public class AuthorizationProvider
    {
        public AuthorizationResult AuthorizeAsync(IOwnedEntity entity, EntityHeader org, EntityHeader user)
        {
            return AuthorizationResult.Authorized;
        }
    }
}
