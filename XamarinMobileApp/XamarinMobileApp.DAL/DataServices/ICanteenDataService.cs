using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices
{
    public interface ICanteenDataService
    {
        Task<RequestResult<CanteenSetDataObject>> GetAllCanteen(CancellationToken cts);
    }
}
