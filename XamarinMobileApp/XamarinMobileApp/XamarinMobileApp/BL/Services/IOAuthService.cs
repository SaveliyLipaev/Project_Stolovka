using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.BL.Services
{
    public interface IOAuthService
    {
        Task<LoginResultObject> Login();
        void Logout();
    }
}
