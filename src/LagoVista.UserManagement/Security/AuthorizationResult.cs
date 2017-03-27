using LagoVista.Core.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.UserManagement.Security
{
    public class AuthorizationResult
    {

        public bool IsAuthorized { get; private set; }
        public static AuthorizationResult Authorized { get { return new AuthorizationResult() { IsAuthorized = true }; } }

        public InvokeResult ToActionResult()
        {
            return new InvokeResult()
            {

            };
        }
    }
}
