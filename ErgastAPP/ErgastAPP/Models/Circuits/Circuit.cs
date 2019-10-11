using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
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

        public string GoogleMapsURI { get { return String.Format("https://www.google.com/maps/search/?api=1&query={0},{1}", Location.Latitud, Location.Longitud); } }
    }
}
