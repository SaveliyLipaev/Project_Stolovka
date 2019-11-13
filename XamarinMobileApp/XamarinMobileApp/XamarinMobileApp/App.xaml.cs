using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMobileApp.UI;

namespace XamarinMobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DialogService.Init(this);
            //DataServices.Init(true);
            NavigationService.Init();
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
