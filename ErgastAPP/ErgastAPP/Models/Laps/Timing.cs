using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ErgastAPP.Models
{
    public class Timing
    {
        [JsonProperty("driverId")]
        public string DriverId { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
