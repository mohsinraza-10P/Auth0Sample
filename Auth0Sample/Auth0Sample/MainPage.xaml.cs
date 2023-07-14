using System.Diagnostics;
using Auth0Sample.Services;
using Xamarin.Forms;

namespace Auth0Sample
{
    public partial class MainPage : ContentPage
    {
        private readonly IAuthService authService;

        public MainPage()
        {
            InitializeComponent();

            BtnLogin.Clicked += BtnLogin_Clicked;
            BtnLogout.Clicked += BtnLogout_Clicked;

            authService = DependencyService.Get<IAuthService>();
        }

        private async void BtnLogin_Clicked(object sender, System.EventArgs e)
        {
            var result = await authService.Login();
            if (result?.IsError ?? true)
            {
                Debug.WriteLine($"Login Error: {result.Error} - {result.ErrorDescription}");
                return;
            }

            Debug.WriteLine($"ID_TOKEN: {result.IdentityToken}");
            Debug.WriteLine($"ACCESS_TOKEN: {result.AccessToken}");
            Debug.WriteLine($"REFRESH_TOKEN: {result.RefreshToken}");
        }

        private async void BtnLogout_Clicked(object sender, System.EventArgs e)
        {
            var result = await authService.Logout();
            if (result)
            {
                Debug.WriteLine($"Logout successful!");
            }
        }
    }
}

