using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class ConstructorStandings
    {
        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("positionText")]
        public string PositionText { get; set; }

        [JsonProperty("points")]
        public double Points { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("Constructor")]
        public Constructor Constructor { get; set; }
    }
}
