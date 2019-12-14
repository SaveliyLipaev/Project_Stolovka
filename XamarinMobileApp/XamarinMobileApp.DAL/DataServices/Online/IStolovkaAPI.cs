using Refit;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices.Online
{
    public interface IStolovkaAPI
    {
        [Get("/canteenlist/get")]
        Task<CanteenSetDataObject> GetAllCanteen(CancellationToken cts);

        [Get("")]
        Task<MenuDataObject> GetMenu(string idCanteen, CancellationToken cts);

        [Post("")]
        Task<string> LoginInApi(LoginResultDataObject loginResult, CancellationToken cts);
    }
}
    