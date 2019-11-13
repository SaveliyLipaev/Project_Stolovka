using Xamarin.Forms;
using XamarinMobileApp.UI;
using XamarinMobileApp.UI.Pages;

namespace XamarinMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DialogService.Init(this);
            //DataServices.Init(true);
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
