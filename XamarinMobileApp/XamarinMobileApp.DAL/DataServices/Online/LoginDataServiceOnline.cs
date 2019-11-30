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
        IStolovkaAPI _stolovkaAPI;

        public LoginDataServiceOnline(IStolovkaAPI stolovkaAPI)
        {
            _stolovkaAPI = stolovkaAPI;
        }

        public Task<RequestResult<string>> LoginInApi(LoginResultDataObject loginResult, CancellationToken cts)
        {
            return MakeRequest(ct => _stolovkaAPI.LoginInApi(loginResult, ct), cts);
        }
    }
}
