using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Qualyfing info.
    /// </summary>
    public class Qualifying
    {
        /// <summary>
        /// Car number.
        /// </summary>
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        /// Qualifying position.
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; set; }

        /// <summary>
        /// Driver who set the times.
        /// <seealso cref="Driver"/>
        /// </summary>
        [JsonProperty("Driver")]
        public Driver Driver { get; set; }

        /// <summary>
        /// Constructor that set the time.
        /// <seealso cref="Constructor"/>
        /// </summary>
        [JsonProperty("Constructor")]
        public Constructor Constructor { get; set; }

        /// <summary>
        /// Time set in the first Qualy round.
        /// </summary>
        [JsonProperty("Q1")]
        public string Q1 { get; set; }

        /// <summary>
        /// Time set in the second Qualy round.
        /// </summary>
        [JsonProperty("Q2")]
        public string Q2 { get; set; }

        /// <summary>
        /// Time set in the third Qualy round.
        /// </summary>
        [JsonProperty("Q3")]
        public string Q3 { get; set; }
    }
}
