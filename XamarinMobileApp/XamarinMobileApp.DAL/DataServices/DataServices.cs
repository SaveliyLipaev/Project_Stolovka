using System;
using System.Threading;
using System.Threading.Tasks;

namespace XamarinMobileApp.DAL.DataServices
{
    public static class DataServices
    {
        public static void Init(bool isMock)
        {
            if (isMock)
            {
                Menu = new Mock.MenuDataService();
                Canteens = new Mock.CanteenDataService();
            }
            else
            {
                Menu = new Online.MenuDataServiceOnline();
                Canteens = new Online.CanteenDataServiceOnline();
            }
        }

        public static IMenuDataService Menu { get; private set; }
        public static ICanteenDataService Canteens { get; private set; }
    }
}