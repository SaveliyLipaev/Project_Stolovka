using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices
{
    public interface IUserDataService
    {
        Task<RequestResult<UserInfoDataObject>> GetUserInfo(string userId, CancellationToken cts);

        Task<RequestResult<UserInfoDataObject>> PutUserInfo(string userId, UserInfoDataObject userInfo, CancellationToken cts);
    }
}
