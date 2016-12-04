using System.Threading.Tasks;

namespace LagoVista.UserManagement.Interfaces.Managers
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}
