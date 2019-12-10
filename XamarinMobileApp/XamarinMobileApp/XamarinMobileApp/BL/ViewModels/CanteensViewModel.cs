using Akavache;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinMobileApp.DAL.DataObjects;
using System.Reactive.Linq;
using XamarinMobileApp.DAL.DataServices;
using XamarinMobileApp.Helpers;

namespace XamarinMobileApp.BL.ViewModels
{
    class CanteensViewModel : BaseViewModel
    {
        public CanteenSetDataObject Canteens
        {
            get => Get<CanteenSetDataObject>();
            set => Set(value);
        }

        protected override async Task LoadDataAsync()
        {
            if (!IsConnected)
            {
                State = PageState.NoInternet;
                return;
            }

            ShowLoading("Загрузка данных по столовкам");
            var result = await DataServices.Canteens.GetAllCanteen(CancellationToken);
            Canteens = result.Data;
            HideLoading();
        }

        public ICommand GoToMenu => MakeCommand((obj) =>
        {
            NavigateTo(Pages.FoodMenu, null, navParams: new Dictionary<string, object> { { "canteen", obj } });
        });

        public ICommand GoToProfile => MakeNavigateToCommand(Pages.Profile);

        public ICommand ExitAccount => MakeCommand(() =>
        {
            BlobCache.UserAccount.InvalidateObject<LoginResultDataObject>("login");
            NavigateTo(Pages.SignIn, null, NavigationMode.RootPage);
        });
    }
}
