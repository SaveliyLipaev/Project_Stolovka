using Akavache;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Reactive.Linq;
using Xamarin.Forms;
using XamarinMobileApp.BL.Services;
using XamarinMobileApp.DAL.DataObjects;
using XamarinMobileApp.Helpers;
using System;

namespace XamarinMobileApp.BL.ViewModels
{
    class SignInViewModel : BaseViewModel
    {
        public string hintLabel
        {
            get => Get<string>();
            set => Set(value);
        }

        public ICommand ConnectWithGoogle => MakeCommand(() =>
        {
            LoginButtonOnClicked("Google");
        });

        public ICommand ConnectWithVk => MakeCommand(() =>
        {
            LoginButtonOnClicked("vk");
        });

        public override  Task OnPageAppearing()
        {
            hintLabel = "Log in please";
            return base.OnPageAppearing();
        }

        protected override async Task LoadDataAsync()
        {
            try
            {
                await BlobCache.UserAccount.GetObject<LoginResultDataObject>("login");
                await NavigateTo(Pages.Canteens, null, NavigationMode.RootPage);
            }
            catch (KeyNotFoundException)
            { }
        }

        async void LoginButtonOnClicked(string provider)
        {
            ShowLoading("Login. Please wait");

            var loginResult = await Login(provider);

            switch (loginResult.LoginState)
            {
                case LoginState.Canceled:
                    hintLabel = "Canceled";
                    HideLoading();
                    break;

                case LoginState.Success:
                    await BlobCache.UserAccount.InsertObject("login", loginResult);
                    await NavigateTo(Pages.Canteens, null, mode: NavigationMode.RootPage);
                    break;

                default:
                    hintLabel = "Failed: " + loginResult.ErrorString;
                    HideLoading();
                    break;
            }
        }

        Task<LoginResultDataObject> Login(string providerName)
        {
            switch (providerName.ToLower())
            {
                case "vk":
                    return DependencyService.Get<IVkService>().Login();
                default:
                    return DependencyService.Get<IOAuthService>().Login();
            }
        }

        void Logout(string providerName)
        {
            switch (providerName.ToLower())
            {
                case "vk":
                    DependencyService.Get<IVkService>().Logout();
                    return;
                default:
                    DependencyService.Get<IOAuthService>().Logout();
                    return;
            }
        }
    }
}
