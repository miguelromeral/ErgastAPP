using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Pit stop info.
    /// </summary>
    public class PitStop
    {
        /// <summary>
        /// Driver ID who made the stop.
        /// </summary>
        [JsonProperty("driverId")]
        public string DriverId { get; set; }

        /// <summary>
        /// Number of lap the driver entered.
        /// </summary>
        [JsonProperty("lap")]
        public int Lap { get; set; }

        /// <summary>
        /// Number of the current stop along the race for this driver.
        /// </summary>
        [JsonProperty("stop")]
        public int Stop { get; set; }

        /// <summary>
        /// Local Time when de Driver made his stop.
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }

        /// <summary>
        /// Time since the driver crossed the Pit Lane limiter until he gets off pit lane.
        /// </summary>
        [JsonProperty("duration")]
        public string Duration { get; set; }
    }
}
