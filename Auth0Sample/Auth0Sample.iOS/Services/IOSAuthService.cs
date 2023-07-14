using Auth0.OidcClient;

namespace Auth0Sample.iOS.Services
{
	public class IOSAuthService : AuthService
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

