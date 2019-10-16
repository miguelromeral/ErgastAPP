using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Driver Standing Model.
    /// </summary>
    public class DriverStandings
    {
        /// <summary>
        /// Driver position.
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; set; }

        /// <summary>
        /// Position in text.
        /// </summary>
        [JsonProperty("positionText")]
        public string PositionText { get; set; }

        /// <summary>
        /// Amount of driver points.
        /// </summary>
        [JsonProperty("points")]
        public double Points { get; set; }

        /// <summary>
        /// Number of wins.
        /// </summary>
        [JsonProperty("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// Driver of the row.
        /// <seealso cref="Driver"/>
        /// </summary>
        [JsonProperty("Driver")]
        public Driver Driver { get; set; }

        /// <summary>
        /// Constructors that the driver has been in.
        /// <seealso cref="Constructor"/>
        /// </summary>
        [JsonProperty("Constructors")]
        public List<Constructor> Constructor { get; set; }

        /// <summary>
        /// Points formatted.
        /// </summary>
        public string PrettyPoints { get { return Standings.DoFormat(Points); } }

        /// <summary>
        /// Last constructor so far the Driver has.
        /// </summary>
        public Constructor LastConstructor { get { return Constructor?[Constructor.Count - 1]; } }

    }
}
