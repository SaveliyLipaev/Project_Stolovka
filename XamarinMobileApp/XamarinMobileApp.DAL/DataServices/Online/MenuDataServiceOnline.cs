﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.DAL.DataServices.Online
{
    class MenuDataServiceOnline : RequestMaker, IMenuDataService
    {
        IStolovkaAPI _stolovkaAPI;

        public MenuDataServiceOnline(IStolovkaAPI stolovkaAPI)
        {
            _stolovkaAPI = stolovkaAPI;
        }

        public Task<RequestResult<MenuDataObject>> GetMenu(string idCanteen, CancellationToken cts)
        {
            return MakeRequest(ct => _stolovkaAPI.GetMenu(idCanteen, ct), cts);
        }
    }
}
