using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using XamarinMobileApp.Helpers;

namespace XamarinMobileApp.BL.ViewModels
{
    class MenuViewModel : BaseViewModel
    {
        public ICommand GoToCanteensCommand => MakeMenuCommand(Pages.Canteens);
        public ICommand GoToBasketCommand => MakeMenuCommand(Pages.Basket);
        public ICommand GoToProfileCommand => MakeMenuCommand(Pages.Profile);

        static ICommand MakeMenuCommand(object page)
        {
            return MakeNavigateToCommand(page, NavigationMode.RootPage, newNavigationStack: true, withAnimation: false);
        }
    }
}
