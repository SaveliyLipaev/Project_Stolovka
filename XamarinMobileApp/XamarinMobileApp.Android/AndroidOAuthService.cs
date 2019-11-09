using System;
using System.Net;
using System.Threading.Tasks;
using XamarinMobileApp.Droid;
using Newtonsoft.Json.Linq;
using Xamarin.Auth;
using Xamarin.Forms;
using XamarinMobileApp.Droid;

[assembly: Dependency(typeof(AndroidOAuthService))]
namespace XamarinMobileApp.Droid
{
    public class AndroidOAuthService : Java.Lang.Object, IOAuthService
    {
        TaskCompletionSource<LoginResult> _completionSource;

        public Task<LoginResult> Login()
        {
            _completionSource = new TaskCompletionSource<LoginResult>();

            var auth = new OAuth2Authenticator
            (
                clientId: "504765177204-1u5irp85sovk26tu9os66r6v3aem4kvg.apps.googleusercontent.com",
                scope: "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/plus.login",
                authorizeUrl: new Uri("https://accounts.google.com/o/oauth2/auth"),
                redirectUrl: new Uri("com.googleusercontent.apps.504765177204-1u5irp85sovk26tu9os66r6v3aem4kvg:/oauth2redirect"),
                clientSecret: null,
                accessTokenUrl: new Uri("https://accounts.google.com/o/oauth2/token"),
                isUsingNativeUI: true
            )
            {
                AllowCancel = true
            };

            auth.Completed += AuthOnCompleted;
            auth.ClearCookiesBeforeLogin = true;
            auth.Title = "Google";

            Forms.Context.StartActivity(auth.GetUI(Forms.Context));

            AuthenticationState.Authenticator = auth;

            return _completionSource.Task;
        }

        private async void AuthOnCompleted(object sender, AuthenticatorCompletedEventArgs authCompletedArgs)
        {
            if (!authCompletedArgs.IsAuthenticated || authCompletedArgs.Account == null)
                SetResult(new LoginResult { LoginState = LoginState.Canceled });
            else
            {
                var token = authCompletedArgs.Account.Properties.ContainsKey("access_token")
                    ? authCompletedArgs.Account.Properties["access_token"]
                    : null;
                var expInString = authCompletedArgs.Account.Properties.ContainsKey("expires_in")
                    ? authCompletedArgs.Account.Properties["expires_in"]
                    : null;

                var expireIn = Convert.ToInt32(expInString);
                var expireAt = DateTimeOffset.Now.AddSeconds(expireIn);

                await GetUserProfile(authCompletedArgs.Account, token, expireAt);
            }
        }

        public void Logout()
        {
            _completionSource = null;
        }

        void SetResult(LoginResult result)
        {
            _completionSource?.TrySetResult(result);
            _completionSource = null;
        }

        async Task GetUserProfile(Account account, string token, DateTimeOffset expireAt)
        {
            var result = new LoginResult
            {
                Token = token,
                ExpireAt = expireAt
            };

            var request = new OAuth2Request("GET", new Uri("https://www.googleapis.com/oauth2/v2/userinfo"),
                null, account);
            var response = await request.GetResponseAsync();
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                var userJson = response.GetResponseText();
                var jobject = JObject.Parse(userJson);
                result.LoginState = LoginState.Success;
                result.Email = jobject["email"]?.ToString();
                result.FirstName = jobject["name"]?.ToString();
            }
            else
            {
                result.LoginState = LoginState.Failed;
                result.ErrorString = $"Error: Responce={response}, StatusCode = {response?.StatusCode}";
            }

            SetResult(result);
        }
    }
}