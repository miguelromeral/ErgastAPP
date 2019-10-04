using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ErgastAPP.Models
{
	public class DataErgastRaces : DataErgast
    {
        [JsonProperty("RaceTable")]
        public RaceTable RaceTable { get; set; }
    }

    public class RaceTable
    {
        [JsonProperty("season")]
        public int Season { get; set; }

        [JsonProperty("Races")]
        public List<Race> Races { get; set; }
    }

    public class Race
    {
        [JsonProperty("season")]
        public int Season { get; set; }

        [JsonProperty("round")]
        public int Round { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("raceName")]
        public string Name { get; set; }
        
        [JsonProperty("Circuit")]
        public Circuit Circuit { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}