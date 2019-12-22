using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMobileApp.DAL.DataObjects
{
    public class RequestOrderDataObject
    {
        public string CanteenId { get; set; }
        public string OrderTime { get; set; } //Вернутся к этому!!!
        public PaymentDataObject PaymentData { get; set; }
        public DishDataObject[] OrderData { get; set; }
    }
}
