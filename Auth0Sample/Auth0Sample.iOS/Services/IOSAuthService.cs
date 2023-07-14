using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Auth0.OidcClient;
using Auth0Sample.iOS.Services;
using Auth0Sample.Services;
using IdentityModel.OidcClient;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSAuthService))]
namespace Auth0Sample.iOS.Services
{
	public class IOSAuthService : IAuthService
    {
        private readonly Auth0Client client;

        public IOSAuthService()
        {
            client = new Auth0Client(new Auth0ClientOptions()
            {
                Domain = Constants.Auth0Domain,
                ClientId = Constants.Auth0ClientId,
                Scope = Constants.Scope,
                LoadProfile = Constants.LoadProfile
            });
        }

        public Task<LoginResult> Login()
        {
            try
            {
                var options = new
                {
                    audience = Constants.Audience,
                    responseType = Constants.ResponseType,
                };

                return client.LoginAsync(options);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[IOSAuthService] Login Exception: {ex}");
            }
            return null;
        }

        public async Task<bool> Logout()
        {
            try
            {
                await client.LogoutAsync();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[IOSAuthService] Logout Exception: {ex}");
            }
            return false;
        }
    }
}

