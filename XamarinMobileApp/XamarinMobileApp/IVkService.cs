using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinMobileApp
{
    public interface IVkService
    {
        Task<LoginResult> Login();
        void Logout();
    }
}
