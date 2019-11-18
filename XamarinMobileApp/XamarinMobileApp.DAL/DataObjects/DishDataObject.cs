using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMobileApp.DAL.DataObjects
{
    public class DishDataObject : BaseDataObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
