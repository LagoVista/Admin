using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.Models.Account
{
    public class ThirdPartyLoginInfo
    {
        public string LoginId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string DisplayName { get; set; }
    }
}
