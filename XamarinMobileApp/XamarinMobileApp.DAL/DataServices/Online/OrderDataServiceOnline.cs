using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices.Online
{
    class OrderDataServiceOnline : RequestMaker, IOrderDataService
    {
        IStolovkaAPI _stolovkaAPI;

        public OrderDataServiceOnline(IStolovkaAPI stolovkaAPI)
        {
            _stolovkaAPI = stolovkaAPI;
        }

        public Task<RequestResult<ResponseOrderDataObject>> GetOrderById(string orderId, CancellationToken cts)
        {
            return MakeRequest(ct => _stolovkaAPI.GetOrderById(orderId, ct), cts);
        }

        public Task<RequestResult<string>> SendOrder(RequestOrderDataObject order, CancellationToken cts)
        {
            return MakeRequest(ct => _stolovkaAPI.SendOrder(order, ct), cts);
        }
    }
}
