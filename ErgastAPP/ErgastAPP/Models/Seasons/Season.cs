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


        public Driver DriverChampion { get; set; }
        public Constructor DriverConstructorChampion { get; set; }
        public Constructor ConstructorChampion { get; set; }
    }
}
