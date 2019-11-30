using Refit;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices.Online
{
    public interface IStolovkaAPI
    {
        [Get("")]
        Task<RequestResult<CanteenSetDataObject>> GetAllCanteen(CancellationToken cts);

        [Get("")]
        Task<RequestResult<MenuDataObject>> GetMenu(string idCanteen, CancellationToken cts);

        [Post("")]
        Task<RequestResult<string>> LoginInApi(LoginResultDataObject loginResult, CancellationToken cts);
    }
}
