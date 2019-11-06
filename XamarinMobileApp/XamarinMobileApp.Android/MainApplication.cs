using Android.App;
using Android.Runtime;
using System;
using VKontakte;

namespace XamarinMobileApp.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            VKSdk.Initialize(this).WithPayments();
        }
    }
}
