using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErgastAPP.Models
{
    public class Standings
    {
        [JsonProperty("season")]
        public int Season { get; set; }

        [JsonProperty("round")]
        public int Round { get; set; }

        [JsonProperty("DriverStandings")]
        public List<DriverStandings> DriverStandings { get; set; }


        public Driver DriverChampion { get { return DriverStandings?.Where(x => x.Position == 1).FirstOrDefault()?.Driver; } }
    }
}
