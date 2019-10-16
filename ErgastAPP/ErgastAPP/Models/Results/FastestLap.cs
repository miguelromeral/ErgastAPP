using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Fastest lap info.
    /// </summary>
    public class FastestLap
    {
        /// <summary>
        /// Number of how fast was the lap in comparission with all the laps of the race.
        /// </summary>
        [JsonProperty("rank")]
        public int Rank { get; set; }
        
        /// <summary>
        /// Number of lap it has been set.
        /// </summary>
        [JsonProperty("lap")]
        public int Lap { get; set; }

        /// <summary>
        /// Time set in the lap.
        /// </summary>
        [JsonProperty("Time")]
        public Time Time { get; set; }

        /// <summary>
        /// Average speed of the lap.
        /// </summary>
        [JsonProperty("AverageSpeed")]
        public AverageSpeed AverageSpeed { get; set; }     
        
        /// <summary>
        /// Displays the fastest lap time formatted.
        /// </summary>
        public string PrettyTime { get { return Time.TotalTime + " on lap " + Lap; } }
    }
}
