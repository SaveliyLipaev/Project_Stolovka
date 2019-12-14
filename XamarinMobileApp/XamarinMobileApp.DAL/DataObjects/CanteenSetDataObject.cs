using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMobileApp.DAL.DataObjects
{
    public class CanteenSetDataObject
    {
        [JsonProperty("canteens")]
        public List<CanteenDataObject> Canteens { get; set; }
    }
}
