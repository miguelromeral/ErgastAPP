using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class StandingsTable
    {
        [JsonProperty("driverStandings")]
        public int DriverStandingsPosition { get; set; }

        [JsonProperty("constructorStandings")]
        public int ConstructorStandingsPosition { get; set; }

        [JsonProperty("StandingsLists")]
        public List<Standings> Standings { get; set; }
    }
}
