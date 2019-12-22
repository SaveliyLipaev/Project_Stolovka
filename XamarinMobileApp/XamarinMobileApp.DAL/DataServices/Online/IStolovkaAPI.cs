using Refit;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices.Online
{
    [Headers("Authorization: Bearer")]
    public interface IStolovkaAPI
    {
        [Get("/api/v1/canteens")]
        Task<CanteenSetDataObject> GetAllCanteens(CancellationToken cts);

        [Get("/api/v1/menus/{canteenId}")]
        Task<MenuDataObject> GetMenu(string idCanteen, CancellationToken cts);

        [Post("/api/v1/buy")]
        Task<string> SendOrder([Body]RequestOrderDataObject order, CancellationToken cts);

        [Get("/api/v1/orders/{orderId}")]
        Task<ResponseOrderDataObject> GetOrderById(string orderId, CancellationToken cts); 
    }
}
    