using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices.Mock
{
    public class UserDataService : BaseMockDataService, IUserDataService
    {
        public Task<RequestResult<UserInfoDataObject>> GetUserInfo(string userId, CancellationToken cts)
        {
            return GetMockData<UserInfoDataObject>(@"XamarinMobileApp.DAL.Resources.Mock.UserInfo.json");
        }

        public Task<RequestResult<UserInfoDataObject>> PutUserInfo(string userId, UserInfoDataObject userInfo, CancellationToken cts)
        {
            throw new NotImplementedException();
        }
    }
}
