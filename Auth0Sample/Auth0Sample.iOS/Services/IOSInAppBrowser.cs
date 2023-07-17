using System;
using System.Threading;
using System.Threading.Tasks;
using Auth0.OidcClient;
using IdentityModel.OidcClient.Browser;
using UIKit;

namespace Auth0Sample.iOS.Services
{
	public class IOSInAppBrowser : AutoSelectBrowser
    {
        protected override Task<BrowserResult> Launch(BrowserOptions options, CancellationToken cancellationToken = default)
        {
            return SafariBrowser.Start(options);
        }
    }
}

