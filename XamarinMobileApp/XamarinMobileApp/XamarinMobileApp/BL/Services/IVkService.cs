using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.BL.Services
{
    public interface IVkService
    {
        Task<LoginResultObject> Login();
        void Logout();
    }
}
