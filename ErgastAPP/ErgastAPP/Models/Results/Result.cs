using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class Result
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("positionText")]
        public string PositionText { get; set; }

        [JsonProperty("points")]
        public double Points { get; set; }

        [JsonProperty("Driver")]
        public Driver Driver { get; set; }

        [JsonProperty("Constructor")]
        public Constructor Constructor { get; set; }

        [JsonProperty("grid")]
        public int Grid { get; set; }

        [JsonProperty("laps")]
        public int Laps { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("Time")]
        public Time Time { get; set; }
        
        [JsonProperty("FastestLap")]
        public FastestLap FastestLap { get; set; }



        public string PrettyResult { get { return (Time != null ? Time.TotalTime : Status); } }
    }
}
