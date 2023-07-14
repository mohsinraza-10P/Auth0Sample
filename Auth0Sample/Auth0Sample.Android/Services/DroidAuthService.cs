using Auth0.OidcClient;

namespace Auth0Sample.Droid.Services
{
    public class DroidAuthService : AuthService
    {
        private Auth0Client client;

        protected override IAuth0Client Client
        {
            get
            {
                if (client == null)
                {
                    client = new Auth0Client(ClientOptions);
                }
                return client;
            }
        }
    }
}

