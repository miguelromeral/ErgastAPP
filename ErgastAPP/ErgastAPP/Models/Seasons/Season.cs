using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class Season
    {
        [JsonProperty("season")]
        public int Year { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
