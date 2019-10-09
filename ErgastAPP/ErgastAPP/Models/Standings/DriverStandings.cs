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


        public string PrettyPoints { get { return DoFormat(Points); } }

        public Constructor LastConstructor { get { return Constructor?[Constructor.Count - 1]; } }

        private string DoFormat(double myNumber)
        {
            var s = string.Format("{0:0.0}", myNumber);

            if (s.EndsWith("0"))
            {
                return ((int)myNumber).ToString();
            }
            else
            {
                return s;
            }
        }
    }
}
