using System.Threading.Tasks;
using IdentityModel.OidcClient;

namespace Auth0Sample.Services
{
	public interface IAuthService
    {
        Task<LoginResult> Login();

        Task<bool> Logout();
    }
}

