using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Race info.
    /// </summary>
    public class RaceTable
    {
        /// <summary>
        /// Season of the races.
        /// </summary>
        [JsonProperty("season")]
        public int Season { get; set; }

        /// <summary>
        /// Number of race in the season.
        /// </summary>
        [JsonProperty("round")]
        public int Round { get; set; }

        /// <summary>
        /// List of races in the table.
        /// <seealso cref="Race"/>
        /// </summary>
        [JsonProperty("Races")]
        public List<Race> Races { get; set; }

        /// <summary>
        /// Driver ID who participated in the races.
        /// </summary>
        [JsonProperty("driverId")]
        public string DriverId { get; set; }

        /// <summary>
        /// Circuit ID where the races was celebrated.
        /// </summary>
        [JsonProperty("circuitId")]
        public string CircuitId { get; set; }
        
        /// <summary>
        /// List of races which it has a winner.
        /// <seealso cref="Race"/>
        /// </summary>
        public List<Race> RacesWon { get { return Races?.Where(x => x.Results[0].Position == 1).ToList(); } }

        /// <summary>
        /// Lisst of races that it has a pole sitter.
        /// <seealso cref="Race"/>
        /// </summary>
        public List<Race> RacesPolePosition { get { return Races?.Where(x => x.Results[0].Grid == 1).ToList(); } }

        /// <summary>
        /// List of races that there was a podium (1,2,3).
        /// <seealso cref="Race"/>
        /// </summary>
        public List<Race> RacesPodiums { get { return Races?.Where(x => x.Results[0].Position == 1 ||
                                                                    x.Results[0].Position == 2 ||
                                                                    x.Results[0].Position == 3).ToList(); } }

        /// <summary>
        /// List of races that there was a DNF.
        /// <seealso cref="Race"/>
        /// </summary>
        public List<Race> RacesDNF { get { return Races?.Where(x => x.Results[0].PositionText == "R").ToList(); } }

        /// <summary>
        /// Number of total points in the race list results.
        /// </summary>
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
