using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Response for standings request.
    /// <seealso cref="DataErgast"/>
    /// </summary>
    public class DataErgastStandings : DataErgast
    {
        /// <summary>
        /// Standings info.
        /// <seealso cref="StandingsTable"/>
        /// </summary>
        [JsonProperty("StandingsTable")]
        public StandingsTable StandingsTable { get; set; }
    }
}
