using Xamarin.Forms;
using XamarinMobileApp.DAL.DataServices;
using XamarinMobileApp.Helpers;
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
            DataServices.Init(false);
            NavigationService.Init(Pages.SignIn);
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
