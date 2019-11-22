using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinMobileApp.DAL.DataObjects;
using XamarinMobileApp.DAL.DataServices;

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
            var result = await DataServices.Canteens.GetAllCanteen(CancellationToken);
            Canteens = result.Data;
        }

        public ICommand GoToMenu => MakeCommand((obj) =>
        {
            NavigateTo(Pages.FoodMenu, null, navParams: new Dictionary<string, object> { { "canteen", obj } });
        });
    }
}
