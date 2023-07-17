using System;
using System.Threading;
using System.Threading.Tasks;
using Auth0.OidcClient;
using Foundation;
using IdentityModel.OidcClient.Browser;
using SafariServices;
using UIKit;

namespace Auth0Sample.iOS.Services
{
	public class SafariBrowser : SFSafariViewControllerBrowser
    {
        internal static Task<BrowserResult> Start(BrowserOptions options)
        {
            var tcs = new TaskCompletionSource<BrowserResult>();

            // Create Safari controller
            var safari = new SFSafariViewController(new NSUrl(options.StartUrl))
            {
                Delegate = new SafariViewControllerDelegate()
            };

            safari.PreferredBarTintColor = UIColor.Clear.FromHexString("#1D65A4");

            async void Callback(string response)
            {
                ActivityMediator.Instance.ActivityMessageReceived -= Callback;

                if (response == "UserCancel")
                {
                    tcs.SetResult(Canceled());
                }
                else
                {
                    await safari.DismissViewControllerAsync(true); // Close Safari
                    safari.Dispose();
                    tcs.SetResult(Success(response));
                }
            }

            ActivityMediator.Instance.ActivityMessageReceived += Callback;

            // Launch Safari
            FindRootController().PresentViewController(safari, true, null);

            return tcs.Task;
        }

        private static UIViewController FindRootController()
        {
            var vc = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (vc.PresentedViewController != null)
                vc = vc.PresentedViewController;
            return vc;
        }

        class SafariViewControllerDelegate : SFSafariViewControllerDelegate
        {
            public override void DidFinish(SFSafariViewController controller)
            {
                ActivityMediator.Instance.Send("UserCancel");
            }
        }

        internal static BrowserResult Canceled()
        {
            return new BrowserResult
            {
                ResultType = BrowserResultType.UserCancel
            };
        }

        internal static BrowserResult UnknownError(string error)
        {
            return new BrowserResult
            {
                ResultType = BrowserResultType.UnknownError,
                Error = error
            };
        }

        internal static BrowserResult Success(string response)
        {
            return new BrowserResult
            {
                Response = response,
                ResultType = BrowserResultType.Success
            };
        }
    }
}

