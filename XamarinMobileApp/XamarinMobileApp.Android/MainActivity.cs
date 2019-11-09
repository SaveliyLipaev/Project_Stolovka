using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using VKontakte;
using Xamarin.Forms;

namespace XamarinMobileApp.Droid
{
    [Activity(Label = "XamarinMobileApp", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            Instance = this;

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //-----------------------------------------------------------------------------------------------
            // Xamarin.Auth initialization

            // Presenters Initialization
            global::Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, bundle);

            // Xamarin.Auth CustomTabs Initialization/Customisation
            global::Xamarin.Auth.CustomTabsConfiguration.ActionLabel = null;
            global::Xamarin.Auth.CustomTabsConfiguration.MenuItemTitle = null;
            global::Xamarin.Auth.CustomTabsConfiguration.AreAnimationsUsed = true;
            global::Xamarin.Auth.CustomTabsConfiguration.IsShowTitleUsed = false;
            global::Xamarin.Auth.CustomTabsConfiguration.IsUrlBarHidingUsed = false;
            global::Xamarin.Auth.CustomTabsConfiguration.IsCloseButtonIconUsed = false;
            global::Xamarin.Auth.CustomTabsConfiguration.IsActionButtonUsed = false;
            global::Xamarin.Auth.CustomTabsConfiguration.IsActionBarToolbarIconUsed = false;
            global::Xamarin.Auth.CustomTabsConfiguration.IsDefaultShareMenuItemUsed = false;

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            bool vkResult;
            var task = VKSdk.OnActivityResultAsync(requestCode, resultCode, data, out vkResult);

            try
            {
                var token = await task;
                AndroidVkService.Instance.SetUserToken(token);
            }
            catch (Exception e)
            {
                var vkException = e as VKException;
                if (vkException == null || vkException.Error.ErrorCode != VKontakte.API.VKError.VkCanceled)
                    AndroidVkService.Instance.SetErrorResult(e.Message);
                else
                    AndroidVkService.Instance.SetCanceledResult();
            }
        }
    }
}