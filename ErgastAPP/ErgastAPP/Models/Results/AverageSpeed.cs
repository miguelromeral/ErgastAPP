using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class AverageSpeed
    {
        [JsonProperty("units")]
        public string Units { get; set; }

        [JsonProperty("speed")]
        public double Speed { get; set; }
    }
}
