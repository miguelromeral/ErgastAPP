using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class Location
    {
        [JsonProperty("lat")]
        public string Latitude { get; set; }

        [JsonProperty("long")]
        public string Longitude { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
