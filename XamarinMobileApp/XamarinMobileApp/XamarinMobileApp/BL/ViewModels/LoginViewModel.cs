using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinMobileApp.BL.Services;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.BL.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        public string hintLabel
        {
            get => Get<string>();
            set => Set(value);
        }

        public ICommand ConnectWithGoogle => MakeCommand((obj) =>
        {
            LoginButtonOnClicked(obj);
        });

        public ICommand ConnectWithVk => MakeCommand((obj) =>
        {
            LoginButtonOnClicked(obj);
        });

        public override Task OnPageAppearing()
        {
            hintLabel = "Unauthenticated";
            return base.OnPageAppearing();
        }

        async void LoginButtonOnClicked(object sender)
        {
            var senderBtn = sender as Button;
            if (senderBtn == null)
            {
                return;
            }

            ShowLoading("Login. Please wait");
            var loginResult = await Login(senderBtn.AutomationId);

            switch (loginResult.LoginState)
            {
                case LoginState.Canceled:
                    hintLabel = "Canceled";
                    HideLoading();
                    break;
                case LoginState.Success:
                    await NavigateTo(Pages.Canteens, null, mode: NavigationMode.RootPage);
                    break;
                default:
                    hintLabel = "Failed: " + loginResult.ErrorString;
                    HideLoading();
                    break;
            }
        }

        Task<LoginResultObject> Login(string providerName)
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
