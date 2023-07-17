using System;
using Android.Content;
using Android.Graphics;
using AndroidX.Browser.CustomTabs;
using Auth0.OidcClient;

namespace Auth0Sample.Droid.Services
{
    public class DriodInAppBrowser : AutoSelectBrowser
    {
		public DriodInAppBrowser(Context context) : base(context)
		{
		}

        protected override void OpenBrowser(Android.Net.Uri uri, Context context = null)
        {
            var customTabIntentBuilder = new CustomTabsIntent.Builder();
            var customTabColorParams = new CustomTabColorSchemeParams.Builder()
                .SetToolbarColor(Color.ParseColor("#1D65A4"))
                .Build();
            customTabIntentBuilder.SetColorSchemeParams(CustomTabsIntent.ColorSchemeLight, customTabColorParams);
            var customTabsIntent = customTabIntentBuilder.Build();

            customTabsIntent.Intent.AddFlags(ActivityFlags.NewTask | ActivityFlags.NoHistory);
            customTabsIntent.LaunchUrl(context, uri);
        }
    }
}

