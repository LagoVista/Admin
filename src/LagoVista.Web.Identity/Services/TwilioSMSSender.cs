using LagoVista.UserManagement.Interfaces.Managers;
using LagoVista.Web.Identity.Interfaces;
using System.Threading.Tasks;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace LagoVista.Web.Identity.Services
{
    public class TwilioSMSSender : ISmsSender
    {
        IAppUserManagementSettings _settings;

        public TwilioSMSSender(IAppUserManagementSettings settings)
        {
            _settings = settings;
        }

        public async Task SendAsync(string number, string contents)
        {

            TwilioClient.Init(_settings.SmsServer.AccountId, _settings.SmsServer.AccessKey);
            var restClient = new TwilioRestClient(_settings.SmsServer.AccountId, _settings.SmsServer.AccessKey);
            await MessageResource.CreateAsync(to: new PhoneNumber(number), from: new PhoneNumber(_settings.FromPhoneNumber), body: contents);
        }
    }
}
