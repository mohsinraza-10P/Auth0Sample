using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Auth0.OidcClient;
using Auth0Sample.Droid.Services;
using Auth0Sample.Services;
using IdentityModel.OidcClient;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidAuthService))]
namespace Auth0Sample.Droid.Services
{
    public class DroidAuthService : IAuthService
    {
        private readonly Auth0Client client;

        public DroidAuthService()
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
            catch(Exception ex)
            {
                Debug.WriteLine($"[DroidAuthService] Login Exception: {ex}");
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
                Debug.WriteLine($"[DroidAuthService] Logout Exception: {ex}");
            }
            return false;
        }
    }
}

