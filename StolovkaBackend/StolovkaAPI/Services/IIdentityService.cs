using StolovkaWebAPI.Contracts.V1.Requests;
using StolovkaWebAPI.Domain;
using System.Threading.Tasks;

namespace StolovkaWebAPI.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);

        Task<AuthenticationResult> LoginAsync(string email, string password);

        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);

        Task<AuthenticationResult> MobileUserLogin(MobileUserLoginRequest mobileUser);
    }
}