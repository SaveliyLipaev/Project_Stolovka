using System;
using System.Collections.Generic;
using System.Text;
using XamarinMobileApp.Helpers;

namespace XamarinMobileApp.DAL.DataObjects
{
    public class DishDataObject : Bindable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public int Count 
        { 
            get => Get<int>();
            set => Set(value); 
        }

        public DishDataObject()
        {
            Count = 1;
        }
    }
}
