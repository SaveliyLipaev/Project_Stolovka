using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices.Online
{
    class LoginDataServiceOnline : RequestMaker, ILoginDataService
    {
        IIdentityAPI _identityAPI;

        public LoginDataServiceOnline(IIdentityAPI identityAPI)
        {
            _identityAPI = identityAPI;
        }

        public Task<RequestResult<AuthSuccessResponse>> LoginInApi(LoginResultDataObject loginResult, CancellationToken cts)
        {
            return MakeRequest(ct => _identityAPI.LoginAsync(loginResult, ct), cts);
        }
    }
}
