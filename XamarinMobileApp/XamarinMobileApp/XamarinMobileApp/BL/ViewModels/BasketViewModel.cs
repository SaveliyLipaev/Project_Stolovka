using System.Collections.Generic;
using System.Windows.Input;
using XamarinMobileApp.DAL.DataObjects;
using XamarinMobileApp.Helpers;

namespace XamarinMobileApp.BL.ViewModels
{
    class BasketViewModel : BaseViewModel
    {
        public int PriceForEverything
        {
            get => Get<int>();
            set => Set(value);
        }

        public List<DishDataObject> BasketList
        {
            get => Get<List<DishDataObject>>();
            set => Set(value);
        }

        public override void OnSetNavigationParams(Dictionary<string, object> navigationParams)
        {
            navigationParams.TryGetValue("dishs", out object dishs);
            BasketList = dishs as List<DishDataObject>;
            navigationParams.TryGetValue("price", out object price);
            PriceForEverything = int.Parse(price as string);
        }

        public ICommand Increase => MakeCommand((obj) =>
        {
            var dish = obj as DishDataObject;
            dish.Count++;
            PriceForEverything += dish.Price;
        });

        public ICommand Reduce => MakeCommand((obj) =>
        {
            var dish = obj as DishDataObject;
            if (dish.Count > 0)
            {
                dish.Count--;
                PriceForEverything -= dish.Price;
            }
        });

        public ICommand GoToOrderPaymentCommand => MakeCommand(() =>
        {
            NavigateTo(Pages.OrderPayment, null, 
                navParams: new Dictionary<string, object> { { "dishs", BasketList }, { "price", PriceForEverything.ToString() } });
        });

    }
}
