using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;
using XamarinMobileApp.DAL.DataServices;

namespace XamarinMobileApp.BL.ViewModels
{
    public class FoodMenuViewModel : BaseViewModel
    {
        public CanteenDataObject Canteen
        {
            get => Get<CanteenDataObject>();
            set => Set(value);
        }

        public MenuDataObject Menu
        {
            get => Get<MenuDataObject>();
            set => Set(value);
        }

        public override void OnSetNavigationParams(Dictionary<string, object> navigationParams)
        {
            navigationParams.TryGetValue("canteen", out object obj);
            Canteen = obj as CanteenDataObject;
        }

        protected override async Task LoadDataAsync()
        {
            if (!IsConnected)
            {
                State = PageState.NoInternet;
                return;
            }
            var result = await DataServices.Menu.GetMenu(Canteen.Id, CancellationToken);
            Menu = result.Data;
        }

    }
}
