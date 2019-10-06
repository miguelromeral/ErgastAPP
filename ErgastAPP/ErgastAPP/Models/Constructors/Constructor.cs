using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class Constructor
    {
        [JsonProperty("constructorId")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }
    }
}
