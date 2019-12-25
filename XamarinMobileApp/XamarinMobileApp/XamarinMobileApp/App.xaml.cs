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
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

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

            NavigationService.Init(Pages.Canteens);
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=e3a65490-aa4d-4773-9733-b07de64c25ae;",
                  typeof(Analytics), typeof(Crashes));
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
