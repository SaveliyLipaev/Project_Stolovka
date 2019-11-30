using System.Threading.Tasks;
using Android.App;
using XamarinMobileApp.Droid;
using VKontakte;
using VKontakte.API;
using Xamarin.Forms;
using XamarinMobileApp.BL.Services;
using XamarinMobileApp.DAL.DataObjects;
using System;

[assembly: Dependency(typeof(AndroidVkService))]
namespace XamarinMobileApp.Droid
{
    public class AndroidVkService : Java.Lang.Object, IVkService
    {
        public static AndroidVkService Instance => DependencyService.Get<IVkService>() as AndroidVkService;

        readonly string[] _permissions = {
            VKScope.Email,
            VKScope.Offline
        };

        TaskCompletionSource<LoginResultDataObject> _completionSource;
        LoginResultDataObject _loginResult;

        public Task<LoginResultDataObject> Login()
        {
            _completionSource = new TaskCompletionSource<LoginResultDataObject>();
            VKSdk.Login(Forms.Context as Activity, _permissions);
            return _completionSource.Task;
        }

        public void Logout()
        {
            _loginResult = null;
            _completionSource = null;
            VKSdk.Logout();
        }

        public void SetUserToken(VKAccessToken token)
        {
            _loginResult = new LoginResultDataObject
            {
                Email = token.Email,
                Token = token.AccessToken,
                Id = token.UserId,
                ExpireAt = FromMsDateTime(token.ExpiresIn),
            };

            Task.Run(GetUserInfo);
        }

        async Task GetUserInfo()
        {
            var request = VKApi.Users.Get(VKParameters.From(VKApiConst.Fields, @"photo_400_orig,"));
            var response = await request.ExecuteAsync();
            var jsonArray = response.Json.OptJSONArray(@"response");
            var account = jsonArray?.GetJSONObject(0);
            if (account != null && _loginResult != null)
            {
                _loginResult.FirstName = account.OptString(@"first_name");
                _loginResult.LastName = account.OptString(@"last_name");
                _loginResult.LoginState = LoginState.Success;
                _loginResult.Distributor = "Vk";
                SetResult(_loginResult);
            }
            else
            {
                SetErrorResult(@"Unable to complete the request of user info");
            }
        }

        public void SetErrorResult(string errorMessage)
        {
            SetResult(new LoginResultDataObject { LoginState = LoginState.Failed, ErrorString = errorMessage });
        }

        public void SetCanceledResult()
        {
            SetResult(new LoginResultDataObject { LoginState = LoginState.Canceled });
        }

        void SetResult(LoginResultDataObject result)
        {
            _completionSource?.TrySetResult(result);
            _loginResult = null;
            _completionSource = null;
        }

        private static DateTimeOffset FromMsDateTime(long? longTimeMillis)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return longTimeMillis != null ? epoch.AddMilliseconds(longTimeMillis.Value) : DateTimeOffset.MinValue;
        }
    }
}