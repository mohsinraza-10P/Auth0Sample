using System.Threading.Tasks;
using Xamarin.Forms;

namespace Auth0Sample
{
    public partial class MainPage : ContentPage
    {
        private readonly AuthService authService;

        public MainPage()
        {
            InitializeComponent();

            authService = new AuthService();
        }

        public async Task Login_ClickedAsync(System.Object sender, System.EventArgs e)
        {
            await authService.SignIn();
        }

        public async Task Logout_Clicked(System.Object sender, System.EventArgs e)
        {
            await authService.SignOut();
        }
    }
}

