using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMobileApp.DAL.DataObjects
{
    public class MenuDataObject
    {
        public string CanteenId { get; set; }
        public List<DishDataObject> Dishes { get; set; }
    }
}
