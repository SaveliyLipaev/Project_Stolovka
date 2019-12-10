using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMobileApp.DAL.DataObjects
{
    public class CanteenDataObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("workTime")]
        public string WorkTime { get; set; }
    }
}
