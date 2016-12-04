using LagoVista.UserManagement.Models;
using System.Threading.Tasks;

namespace LagoVista.Web.Identity.Repos
{
    public interface ITokenRepo
    {
        Task<RefreshToken> GetRefreshTokenAsync(string tokenId, string userId);
        Task RemoveRefreshTokenAsync(string userId, string tokenId);
        Task SaveRefreshTokenAsync(RefreshToken token);
    }
}