using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class DataErgastCircuits : DataErgast
    {
        [JsonProperty("CircuitTable")]
        public CircuitTable CircuitTable { get; set; }
    }

    public class CircuitTable
    {
        [JsonProperty("Circuits")]
        public List<Circuit> Circuits { get; set; }
    }

    public class Circuit
    {
        [JsonProperty("circuitId")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("circuitName")]
        public string Name { get; set; }

        [JsonProperty("Location")]
        public Location Location { get; set; }
    }
}
