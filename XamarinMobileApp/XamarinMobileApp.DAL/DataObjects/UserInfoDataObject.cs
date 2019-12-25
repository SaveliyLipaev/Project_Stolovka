
using System.Collections.Generic;

namespace XamarinMobileApp.DAL.DataObjects
{
    public class UserInfoDataObject
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public List<CardInfoDataObject> Cards { get; set; }
    }
}
