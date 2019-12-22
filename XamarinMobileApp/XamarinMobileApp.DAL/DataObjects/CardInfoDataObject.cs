using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMobileApp.DAL.DataObjects
{
    public class CardInfoDataObject
    {
        public string CardId { get; set; }
        public string CardNumber { get; set; }
        public string CardholderFirstName { get; set; }
        public string CardholderLastName { get; set; }
        public int ExparathionYear { get; set; }
        public int ExparathionMounth { get; set; }
    }
}
