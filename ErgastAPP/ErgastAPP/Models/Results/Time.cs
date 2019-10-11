﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class Time
    {
        [JsonProperty("millis")]
        public string Millis { get; set; }

        [JsonProperty("time")]
        public string TotalTime { get; set; }
    }
}
