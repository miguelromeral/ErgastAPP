using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class Location
    {
        [JsonProperty("lat")]
        public string Latitud { get; set; }

        [JsonProperty("long")]
        public string Longitud { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        public string Address { get { return Country + ": " + Locality; } }
    }
}
