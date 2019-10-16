using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Lap Model
    /// Displays the info of a lap.
    /// <see cref="https://ergast.com/mrd/methods/laps/"/>
    /// </summary>
    public class Lap
    {
        /// <summary>
        /// Lap number, begining from 1.
        /// </summary>
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        /// List of every timing set by the drivers on this lap umber.
        /// </summary>
        [JsonProperty("Timings")]
        public List<Timing> Timings { get; set; }
    }
}
