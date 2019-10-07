using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class Qualifying
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("Driver")]
        public Driver Driver { get; set; }

        [JsonProperty("Constructor")]
        public Constructor Constructor { get; set; }

        [JsonProperty("Q1")]
        public string Q1 { get; set; }

        [JsonProperty("Q2")]
        public string Q2 { get; set; }

        [JsonProperty("Q3")]
        public string Q3 { get; set; }
    }
}
