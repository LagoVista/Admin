using LagoVista.UserManagement.Interfaces;
using LagoVista.UserManagement.Interfaces.Managers;
using LagoVista.Web.Identity.Interfaces;
using System;
using System.Threading.Tasks;

namespace LagoVista.Web.Identity.Services
{
    public class SendGridEmailService : IEmailSender
    {
        IAppUserManagementSettings _settings;
        IAppConfig _appConfig;

        public SendGridEmailService(IAppUserManagementSettings settings, IAppConfig appConfig)
        {
            _settings = settings;
            _appConfig = appConfig;
        }

        public Task SendAsync(string email, string subject, string body)
        {
            var client = new System.Net.Mail.SmtpClient(_settings.SmtpServer.Uri, Convert.ToInt32(587));
            client.Port = 587;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(_settings.SmtpServer.UserName, _settings.SmtpServer.Password);

            body = $@"<body>
<img src=""{_appConfig.AppLogo}"" />
<h1>{_appConfig.AppName}</h1>
<h2>{subject}</h2>
{body}
</body>";

            var mail = new System.Net.Mail.MailMessage(_settings.SmtpFrom, email);
            mail.IsBodyHtml = true;
            mail.Subject = subject;
            mail.Body = body;

            return client.SendMailAsync(mail);
        }
    }
}
