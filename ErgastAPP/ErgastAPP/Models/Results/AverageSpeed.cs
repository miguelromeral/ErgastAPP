using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Average race speed.
    /// </summary>
    public class AverageSpeed
    {
        /// <summary>
        /// Unit of measurement (kph).
        /// </summary>
        [JsonProperty("units")]
        public string Units { get; set; }

        /// <summary>
        /// Speed value.
        /// </summary>
        [JsonProperty("speed")]
        public double Speed { get; set; }
    }
}
