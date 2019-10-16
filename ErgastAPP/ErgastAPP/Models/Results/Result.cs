using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Result of a driver in one race.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Car number.
        /// </summary>
        [JsonProperty("number")]
        public int Number { get; set; }

        /// <summary>
        /// Driver position at the end of the race.
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; set; }

        /// <summary>
        /// Position at the end of the race.
        /// </summary>
        [JsonProperty("positionText")]
        public string PositionText { get; set; }

        /// <summary>
        /// Points obtained in the race.
        /// </summary>
        [JsonProperty("points")]
        public double Points { get; set; }

        /// <summary>
        /// Driver who has this result.
        /// <seealso cref="Driver"/>
        /// </summary>
        [JsonProperty("Driver")]
        public Driver Driver { get; set; }

        /// <summary>
        /// Constructor that gets this result.
        /// <seealso cref="Constructor"/>
        /// </summary>
        [JsonProperty("Constructor")]
        public Constructor Constructor { get; set; }

        /// <summary>
        /// Grid position when the race started.
        /// </summary>
        [JsonProperty("grid")]
        public int Grid { get; set; }

        /// <summary>
        /// Number of laps made in the race.
        /// </summary>
        [JsonProperty("laps")]
        public int Laps { get; set; }

        /// <summary>
        /// Finish status of the driver.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Time completed in the race.
        /// <seealso cref="Time"/>
        /// </summary>
        [JsonProperty("Time")]
        public Time Time { get; set; }
        
        /// <summary>
        /// Fastest lap made by the driver.
        /// <seealso cref="FastestLap"/>
        /// </summary>
        [JsonProperty("FastestLap")]
        public FastestLap FastestLap { get; set; }

        /// <summary>
        /// Displays the position more legible.
        /// </summary>
        public string PrettyPosition
        {
            get
            {
                if (int.TryParse(PositionText, out int n))
                    return PositionText;
                else
                {
                    switch (PositionText)
                    {
                        case "R": return "RET";
                        case "D": return "DSQ";
                        case "E": return "EXC";
                        case "W": return "RET";
                        case "F": return "DNQ";
                        case "N": return "DNC";
                        default: return "";
                    }
                }
            }
        }
        
        /// <summary>
        /// Displays the grid position more legible.
        /// It substitutes the 0 grid position by "PL" indicating that the driver started on the Pit Lane.
        /// </summary>
        public string PrettyGrid { get { return (Grid != 0 ? Grid.ToString() : "PL"); } }

        /// <summary>
        /// Displays the time if there is or the final status.
        /// </summary>
        public string PrettyResult { get { return (Time != null ? Time.TotalTime : Status); } }
    }
}
