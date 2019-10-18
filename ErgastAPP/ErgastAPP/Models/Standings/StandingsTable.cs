using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Standings info.
    /// </summary>
    public class StandingsTable
    {
        /// <summary>
        /// Position of the driver standings.
        /// </summary>
        [JsonProperty("driverStandings")]
        public int DriverStandingsPosition { get; set; }

        /// <summary>
        /// Position of the construcotr standings.
        /// </summary>
        [JsonProperty("constructorStandings")]
        public int ConstructorStandingsPosition { get; set; }

        /// <summary>
        /// List of standings.
        /// <seealso cref="Standings"/>
        /// </summary>
        [JsonProperty("StandingsLists")]
        public List<Standings> Standings { get; set; }
    }
}
