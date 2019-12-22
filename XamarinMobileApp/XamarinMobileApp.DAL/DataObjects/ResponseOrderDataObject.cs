using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMobileApp.DAL.DataObjects
{
    public class ResponseOrderDataObject
    {
        public string OrderId { get; set; }
        public string OrderTime { get; set; }
        public string ClientName{ get; set; }
        public string Status { get; set; }
        public string ConfermationCode { get; set; }
    }
}
