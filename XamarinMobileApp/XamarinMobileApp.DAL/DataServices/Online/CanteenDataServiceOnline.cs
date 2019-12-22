using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices.Online
{
    class CanteenDataServiceOnline : RequestMaker, ICanteenDataService
    {
        IStolovkaAPI _stolovkaAPI;

        public CanteenDataServiceOnline(IStolovkaAPI stolovkaAPI)
        {
            _stolovkaAPI = stolovkaAPI;
        }

        public Task<RequestResult<CanteenSetDataObject>> GetAllCanteen(CancellationToken cts)
        {
            return MakeRequest(ct => _stolovkaAPI.GetAllCanteens(ct), cts);
        }
    }
}
