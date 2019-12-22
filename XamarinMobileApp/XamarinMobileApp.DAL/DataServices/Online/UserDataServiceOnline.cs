using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices.Online
{
    class UserDataServiceOnline : RequestMaker, IUserDataService
    {
        IStolovkaAPI _stolovkaAPI;

        public UserDataServiceOnline(IStolovkaAPI stolovkaAPI)
        {
            _stolovkaAPI = stolovkaAPI;
        }

        public Task<RequestResult<UserInfoDataObject>> GetUserInfo(string userId, CancellationToken cts)
        {
            return MakeRequest(ct => _stolovkaAPI.GetUserInfo(userId, ct), cts);
        }

        public Task<RequestResult<UserInfoDataObject>> PutUserInfo(string userId, UserInfoDataObject userInfo, CancellationToken cts)
        {
            return MakeRequest(ct => _stolovkaAPI.PutUserInfo(userId, userInfo, ct), cts);
        }
    }
}
