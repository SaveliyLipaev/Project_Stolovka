using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices.Mock
{
    public class MenuDataService : BaseMockDataService, IMenuDataService
    {
        public Task<RequestResult<MenuDataObject>> GetMenu(string idCanteen, CancellationToken cts)
        {
            return GetMockData<MenuDataObject>(@"XamarinMobileApp.DAL.Resources.Mock.MenuInfo.json");
        }
    }
}
