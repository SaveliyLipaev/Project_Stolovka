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

            global::Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, bundle);

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