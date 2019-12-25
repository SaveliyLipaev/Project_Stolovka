using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices.Online
{
    public interface IIdentityAPI
    {
        [Post("/api/v1/identity/login")]
        Task<AuthSuccessResponse> LoginAsync([Body] LoginResultDataObject loginRequest, CancellationToken cancellationToken);
    }
}
