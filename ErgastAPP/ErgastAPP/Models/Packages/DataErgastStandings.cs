using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class DataErgastStandings : DataErgast
    {
        [JsonProperty("StandingsTable")]
        public StandingsTable StandingsTable { get; set; }
    }
}
