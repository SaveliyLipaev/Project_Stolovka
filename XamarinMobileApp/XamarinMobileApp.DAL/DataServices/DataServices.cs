using ModernHttpClient;
using Refit;
using System;
using System.Net.Http;
using XamarinMobileApp.DAL.DataServices.Online;

namespace XamarinMobileApp.DAL.DataServices
{
    public static class DataServices
    {
        static IStolovkaAPI _stolovkaAPI;

        public static void Init(bool isMock)
        {
            if (isMock)
            {
                Menu = new Mock.MenuDataService();
                Canteens = new Mock.CanteenDataService();
            }
            else
            {
                var client = new HttpClient(new NativeMessageHandler())
                {
                    BaseAddress = new Uri("109.94.208.43:80")
                };

                _stolovkaAPI = RestService.For<IStolovkaAPI>(client);

                Menu = new Online.MenuDataServiceOnline(_stolovkaAPI);
                Canteens = new Online.CanteenDataServiceOnline(_stolovkaAPI);
                Login = new Online.LoginDataServiceOnline(_stolovkaAPI);
            }
        }

        public static IMenuDataService Menu { get; private set; }
        public static ICanteenDataService Canteens { get; private set; }
        public static ILoginDataService Login { get; private set; }
    }
}