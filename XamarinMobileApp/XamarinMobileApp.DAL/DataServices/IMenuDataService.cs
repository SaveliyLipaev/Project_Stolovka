using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices
{
    public interface IMenuDataService
    {
        Task<RequestResult<MenuDataObject>> GetMenu(string idCanteen, CancellationToken cts);
    }
}
