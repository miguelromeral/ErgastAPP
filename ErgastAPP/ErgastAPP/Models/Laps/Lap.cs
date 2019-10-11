using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErgastAPP.Models
{
    public class Lap
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("Timings")]
        public List<Timing> Timings { get; set; }
    }
}
