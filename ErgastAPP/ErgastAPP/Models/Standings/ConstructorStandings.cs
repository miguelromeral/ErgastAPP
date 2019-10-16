using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Constructor Standing Model.
    /// </summary>
    public class ConstructorStandings
    {
        /// <summary>
        /// Constructor position.
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; set; }

        /// <summary>
        /// Position in formatted text.
        /// </summary>
        [JsonProperty("positionText")]
        public string PositionText { get; set; }

        /// <summary>
        /// Amount of points in the standings.
        /// </summary>
        [JsonProperty("points")]
        public double Points { get; set; }

        /// <summary>
        /// Number of wins.
        /// </summary>
        [JsonProperty("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// Constructor of the row.
        /// </summary>
        [JsonProperty("Constructor")]
        public Constructor Constructor { get; set; }

        /// <summary>
        /// Amount of points formatted to string.
        /// </summary>
        public string PrettyPoints { get { return Standings.DoFormat(Points); } }
    }
}
