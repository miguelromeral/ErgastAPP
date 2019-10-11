using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [JsonProperty("driverId")]
        public string DriverId { get; set; }


        public List<Race> RacesWon { get { return Races?.Where(x => x.Results[0].Position == 1).ToList(); } }
        public List<Race> RacesPolePosition { get { return Races?.Where(x => x.Results[0].Grid == 1).ToList(); } }
        public List<Race> RacesPodiums { get { return Races?.Where(x => x.Results[0].Position == 1 ||
                                                                    x.Results[0].Position == 2 ||
                                                                    x.Results[0].Position == 3).ToList(); } }

        public double TotalPoints
        {
            get
            {
                double total = 0;
                foreach(var r in Races)
                {
                    foreach(var res in r.Results)
                    {
                        total += res.Points;
                    }
                }
                return total;
            }
        }
    }
}
