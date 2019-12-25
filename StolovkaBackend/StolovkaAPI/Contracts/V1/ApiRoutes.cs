namespace StolovkaWebAPI.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Canteens
        {
            public const string GetAll = Base + "/canteens";
        }

        public static class Menus
        {
            public const string Get = Base + "/menus/{canteenId}";
        }

        public static class Orders
        {
            public const string Get = Base + "/orders/{orderId}";

            public const string Send = Base + "/orders";
        }

        public static class Users
        {
            public const string Get = Base + "/users/{userId}";

            public const string Put = Base + "/users/{userId}";
        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";

            public const string Refresh = Base + "/identity/refresh";

            public const string MobileUserLogin = Base + "/identity/mobileuserlogin";
        }
    }
}