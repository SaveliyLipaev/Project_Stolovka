using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinMobileApp.Helpers;

namespace XamarinMobileApp.DAL.DataObjects
{
    public class DishDataObject : Bindable
    {
        [JsonProperty("dishId")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonIgnore]
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
