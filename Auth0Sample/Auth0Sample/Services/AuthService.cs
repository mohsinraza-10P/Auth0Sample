using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Auth0.OidcClient;
using IdentityModel.OidcClient;
using Xamarin.Essentials;

namespace Auth0Sample
{
	public class AuthService
    {
        protected virtual IAuth0Client Client { get; }

        protected Auth0ClientOptions ClientOptions { get; }

        public AuthService()
        {
            ClientOptions = new Auth0ClientOptions()
            {
                Domain = Constants.Auth0Domain,
                ClientId = Constants.Auth0ClientId,
                Scope = Constants.Scope,
                LoadProfile = Constants.LoadProfile
            };
        }

        public async Task<bool> SignIn()
        {
            try
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    var options = new
                    {
                        audience = Constants.Audience,
                        responseType = Constants.ResponseType,
                        scope = Constants.Scope
                    };

                    LoginResult result = await Client.LoginAsync(options);
                    if (result?.IsError ?? true)
                    {
                        Debug.WriteLine($"[Auth0Sample] SignIn Error: {result}");
                        return false;
                    }

                    Debug.WriteLine($"[Auth0Sample] SignIn Success!");
                    Debug.WriteLine($"[Auth0Sample] ID_TOKEN: {result.IdentityToken}");
                    Debug.WriteLine($"[Auth0Sample] ACCESS_TOKEN: {result.AccessToken}");
                    Debug.WriteLine($"[Auth0Sample] REFRESH_TOKEN: {result.RefreshToken}");

                    return true;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Auth0Sample] SignIn Exception: {ex}");
            }
            return false;
        }

        public async Task<bool> SignOut()
        {
            try
            {
                await Client.LogoutAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Auth0Sample] SignOut Exception: {ex}");
            }
            return false;
        }
    }
}

