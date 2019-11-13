﻿using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.BL.Services
{
    public interface IVkService
    {
        Task<LoginResult> Login();
        void Logout();
    }
}
