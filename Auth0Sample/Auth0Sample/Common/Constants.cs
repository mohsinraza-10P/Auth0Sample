namespace Auth0Sample
{
	public static class Constants
    {
        public const string Https = "https://";

        public const string AppPackageName = "com.tenpearls.auth0sample";

        public const string Auth0Domain = "theyield-dev-sit.au.auth0.com";

        public const string Auth0ClientId = "XsalWiCKTyKMNTppn7aiLwUogKrL2Lp4";

        public const string DroidIntentPath = "/android/" + AppPackageName + "/callback";

        public const string Scope = "openid profile offline_access";

        public const string ResponseType = "code";

        public const string Audience = Https + "api.dev.theyield.com";

        public const bool LoadProfile = true;

    }
}

