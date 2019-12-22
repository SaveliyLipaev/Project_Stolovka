using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinMobileApp.BL.ViewModels;

namespace XamarinMobileApp.UI.Pages
{
    public interface IBasePage : IDisposable
    {
        void OnParentSet();

        void OnAppearing();

        void OnDisappearing();
    }
}
