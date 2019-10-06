using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class FastestLap
    {
        [JsonProperty("rank")]
        public int Rank { get; set; }
        
        [JsonProperty("lap")]
        public int Lap { get; set; }

        [JsonProperty("Time")]
        public Time Time { get; set; }

        [JsonProperty("AverageSpeed")]
        public AverageSpeed AverageSpeed { get; set; }                            
    }
}
