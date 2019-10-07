﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErgastAPP.Models
{
    public class Race
    {
        [JsonProperty("season")]
        public int Season { get; set; }

        [JsonProperty("round")]
        public int Round { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("raceName")]
        public string Name { get; set; }

        [JsonProperty("Circuit")]
        public Circuit Circuit { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("Results")]
        public List<Result> Results { get; set; }


        public Result Winner { get { return Results?.Where(x => x.Position == 1).FirstOrDefault(); } }

        public Result FastestLap { get { return Results?.Where(x => x.FastestLap.Rank == 1).FirstOrDefault(); } }
    }
}
