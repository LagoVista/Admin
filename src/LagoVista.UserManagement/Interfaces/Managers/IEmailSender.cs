using System.Threading.Tasks;

namespace LagoVista.UserManagement.Interfaces.Managers
{
    public interface IEmailSender
    {
        Task SendAsync(string email, string subject, string message);
    }
}
