using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices
{
    public interface ILoginDataService
    {
        Task<RequestResult<string>> LoginInApi(LoginResultDataObject loginResult, CancellationToken cts);
    }
}
