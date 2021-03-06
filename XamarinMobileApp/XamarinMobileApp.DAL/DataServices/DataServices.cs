using Akavache;
using ModernHttpClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using System;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataServices.Online;

namespace XamarinMobileApp.DAL.DataServices
{
    public static class DataServices
    {
        static IStolovkaAPI _stolovkaAPI;
        static IIdentityAPI _identityAPI;

        public static void Init(bool isMock)
        {
            if (isMock)
            {
                Menu = new Mock.MenuDataService();
                Canteens = new Mock.CanteenDataService();
                User = new Mock.UserDataService();
            }
            else
            {
                var client = new HttpClient(new NativeMessageHandler())
                {
                    BaseAddress = new Uri("http://109.94.208.43:5000/")
                };

                _identityAPI = RestService.For<IIdentityAPI>(client);
                _stolovkaAPI = RestService.For<IStolovkaAPI>(client);

                Menu = new Online.MenuDataServiceOnline(_stolovkaAPI);
                Canteens = new Online.CanteenDataServiceOnline(_stolovkaAPI);
                User = new Online.UserDataServiceOnline(_stolovkaAPI);
                Order = new Online.OrderDataServiceOnline(_stolovkaAPI);
                Login = new Online.LoginDataServiceOnline(_identityAPI);
            }
        }

        public static IMenuDataService Menu { get; private set; }
        public static ICanteenDataService Canteens { get; private set; }
        public static ILoginDataService Login { get; private set; }
        public static IUserDataService User { get; private set; }
        public static IOrderDataService Order { get; private set; }

    }
}