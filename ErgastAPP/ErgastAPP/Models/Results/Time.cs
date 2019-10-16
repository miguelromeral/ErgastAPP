using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Lap Time.
    /// </summary>
    public class Time
    {
        /// <summary>
        /// Time in milliseconds in string format.
        /// </summary>
        [JsonProperty("millis")]
        public string Millis { get; set; }

        /// <summary>
        /// Total time with a formatted way.
        /// </summary>
        [JsonProperty("time")]
        public string TotalTime { get; set; }
    }
}
