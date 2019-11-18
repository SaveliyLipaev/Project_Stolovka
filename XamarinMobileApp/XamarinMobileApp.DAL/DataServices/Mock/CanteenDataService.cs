using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices.Mock
{
    public class CanteenDataService : BaseMockDataService, ICanteenDataService
    {
        public Task<RequestResult<CanteenSetDataObject>> GetAllCanteen(CancellationToken cts)
        {
            return GetMockData<CanteenSetDataObject>(@"XamarinMobileApp.DAL.Resources.Mock.CanteenSetInfo.json");
        }
    }
}
