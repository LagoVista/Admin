using LagoVista.Core.Models;
using System;

namespace LagoVista.UserManagement.Models
{
    public class RefreshToken : TableStorageEntity
    {
        public string Subject { get; set; }
        public string ClientId { get; set; }
        public String IssuedUtc { get; set; }
        public String ExpiresUtc { get; set; }
        public string ProtectedTicket { get; set; }
        public bool Enabled { get; set; }

        public RefreshToken()
        {
            Enabled = true;
        }
    }

}
