using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ErgastAPP.Models
{
    /// <summary>
    /// Timing details.
    /// </summary>
    public class Timing
    {
        /// <summary>
        /// Driver ID who did the lap.
        /// </summary>
        [JsonProperty("driverId")]
        public string DriverId { get; set; }

        /// <summary>
        /// Driver position at this lap.
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; set; }

        /// <summary>
        /// Time in M:ss.tcm format.
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
