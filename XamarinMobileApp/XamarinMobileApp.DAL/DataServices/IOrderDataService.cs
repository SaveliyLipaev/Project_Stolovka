using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices
{
    public interface IOrderDataService
    {
        Task<RequestResult<string>> SendOrder(RequestOrderDataObject order, CancellationToken cts);

        Task<RequestResult<ResponseOrderDataObject>> GetOrderById(string orderId, CancellationToken cts);
    }
}
