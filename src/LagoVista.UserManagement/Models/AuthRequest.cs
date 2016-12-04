using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.UserManagement.Models
{
    public class AuthRequest
    {
        
        public string GrantType { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String RefreshToken { get; set; }
    }
}
