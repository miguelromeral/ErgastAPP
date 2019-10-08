using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class DriverStandings
    {
        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("positionText")]
        public string PositionText { get; set; }

        [JsonProperty("points")]
        public double Points { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("Driver")]
        public Driver Driver { get; set; }

        [JsonProperty("Constructors")]
        public List<Constructor> Constructor { get; set; }

    }
}
