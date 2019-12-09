using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinMobileApp.DAL.DataObjects;
using XamarinMobileApp.DAL.DataServices;
using XamarinMobileApp.Helpers;

namespace XamarinMobileApp.BL.ViewModels
{
    public class FoodMenuViewModel : BaseViewModel
    {
        public List<DishDataObject> listDish = new List<DishDataObject>();

        public decimal PriceForEverything
        {
            get => Get<decimal>();
            set => Set(value);
        }

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
            PriceForEverything = 0;
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

        public ICommand AddToBasket => MakeCommand((obj) =>
        {
            var dish = obj as DishDataObject;
            AddInDishList(dish);
            ShowToast($"{dish.Name} добавлено в корзину");
            PriceForEverything += dish.Price;
        });

        public ICommand GoToBasket => MakeCommand(() =>
        {
            NavigateTo(Pages.Basket, Pages.FoodMenu, 
                navParams: new Dictionary<string, object> { { "dishs", listDish }, { "price", PriceForEverything.ToString() } });
        });

        private void AddInDishList(DishDataObject dish)
        {
            var index = listDish.IndexOf(dish);
            if (index != -1)
            {
                listDish[index].Count++;
            }
            else
            {
                listDish.Add(dish);
            }
        }
    }
}
