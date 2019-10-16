using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Season Model.
    /// </summary>
    public class Season
    {
        /// <summary>
        /// Year of the season.
        /// </summary>
        [JsonProperty("season")]
        public int Year { get; set; }

        /// <summary>
        /// Wikipedia URL report of the season.
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }

        /// <summary>
        /// Driver Champion of the season.
        /// </summary>
        public Driver DriverChampion { get; set; }

        /// <summary>
        /// Constructor of the Driver Champion.
        /// </summary>
        public Constructor DriverConstructorChampion { get; set; }

        /// <summary>
        /// Constructor Champion of the season.
        /// </summary>
        public Constructor ConstructorChampion { get; set; }
    }
}
