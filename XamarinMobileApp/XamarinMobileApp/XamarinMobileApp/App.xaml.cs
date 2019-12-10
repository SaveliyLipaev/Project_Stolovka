using Akavache;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinMobileApp.DAL.DataServices;
using XamarinMobileApp.Helpers;
using XamarinMobileApp.UI;
using XamarinMobileApp.UI.Pages;
using System.Reactive.Linq;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DialogService.Init(this);

            DataServices.Init(true);

            Akavache.Registrations.Start("XamarinMobileApp");

            NavigationService.Init(Pages.SignIn);
        }

        protected override void OnStart()
        {

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
