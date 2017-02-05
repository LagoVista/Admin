using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using System;

namespace LagoVista.Web.Identity.Interfaces
{
    public interface IAppUserManagementSettings
    {
        String SmtpFrom { get; }
        string FromPhoneNumber { get; }

        IConnectionSettings SmsServer { get; }
        IConnectionSettings SmtpServer { get; }
        IConnectionSettings UserStorage { get; }
        IConnectionSettings UserTableStorage { get; }

        
        TimeSpan AccessTokenExpiresTimeSpan { get; }
        TimeSpan RefreshTokenExpiresTimeSpan { get; }

        bool ShouldConsolidateCollections { get; }
    }
}
