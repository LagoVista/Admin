using LagoVista.Common.Interfaces;
using LagoVista.Common.Models;
using LagoVista.Common.Web.Identity.Interfaces;
using System;


namespace LagoVista.IoT.DeviceManagementRepo.Tests.Helpers
{
    public class FakeAppUserManagementSettings : IAppUserManagementSettings
    {
        public TimeSpan AccessTokenExpiresTimeSpan
        {
            get
            {
                return TimeSpan.FromMinutes(30);
            }
        }

        public string FromPhoneNumber
        {
            get
            {
                return "(813) 336-3274";
            }
        }

        public TimeSpan RefreshTokenExpiresTimeSpan
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IConnectionSettings SmsServer
        {
            get
            {
                return new ConnectionSettings()
                {
                    AccountId = "AC77e041ce085f0955f90521414da8d410",
                    AccessKey = "7adebb0b2b7e86d818681e8b57eabdfc"
                };
            }
        }

        public string SmtpFrom
        {
            get
            {
                return "admin@bytemaster.io";
            }
        }

        public IConnectionSettings SmtpServer
        {
            get
            {
                return new ConnectionSettings()
                {
                    Uri = "smtp.sendgrid.net",
                    AccessKey = "SendGridEmailPassword1234",
                    ResourceName = "azure_49397867517f2b5969dfbfe4670532b4@azure.com",
                };
            }
        }

        public IConnectionSettings UserStorage
        {
            get
            {
                return new ConnectionSettings()
                {
                    Uri = "https://bytemaster.documents.azure.com:443",
                    AccessKey = "5GZFhuAmtsnNXrYsWbLoK4DNRMyfEQIUjXiiLv7AZNk1vzItQXm6bc3JRFUkO9oxekzMufNuF0em3EIYFHeSeA==",
                    ResourceName = "Test"

                };
            }
        }

        public IConnectionSettings UserTableStorage
        {
            get
            {
                return new ConnectionSettings()
                {
                    ResourceName = "bytemaster",
                    AccessKey = "uBcUPDdtYuDMLuydcFZ+UnzwpLA7yIP2Ibw1svuODRYbvGv0ZL6pA5moO4Y9BR15XbghY+zyqnmaypq8JXo+qQ==",

                };
            }
        }

    }
}
