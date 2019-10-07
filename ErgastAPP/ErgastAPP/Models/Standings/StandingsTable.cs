using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class StandingsTable
    {
        //[JsonProperty("season")]
        //public int Season { get; set; }

        [JsonProperty("driverStandings")]
        public int Position{ get; set; }

        [JsonProperty("StandingsLists")]
        public List<Standings> Standings { get; set; }
    }
}
