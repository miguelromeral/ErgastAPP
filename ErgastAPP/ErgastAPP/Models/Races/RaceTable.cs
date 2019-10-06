using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class RaceTable
    {
        [JsonProperty("season")]
        public int Season { get; set; }

        [JsonProperty("round")]
        public int Round { get; set; }

        [JsonProperty("Races")]
        public List<Race> Races { get; set; }
    }
}
