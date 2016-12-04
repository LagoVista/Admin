using LagoVista.Core.PlatformSupport;
using LagoVista.UserManagement.Interfaces;
using LagoVista.UserManagement.Interfaces.Repos.Account;

namespace LagoVista.UserManagement.Managers
{
    public class AccountManager : ManagerBase
    {
        public AccountManager(IAccountRepo accountRepo, 
            ILogger logger, 
            IAppConfig appConfig) : base(accountRepo, logger, appConfig)
        {

        }


    }
}
