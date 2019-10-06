using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class CircuitTable
    {
        [JsonProperty("Circuits")]
        public List<Circuit> Circuits { get; set; }
    }
}
