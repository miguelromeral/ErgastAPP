using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Circuit Model.
    /// <see cref="https://ergast.com/mrd/methods/circuits/"/>
    /// </summary>
    public class Circuit
    {
        /// <summary>
        /// Circuit PK.
        /// </summary>
        [JsonProperty("circuitId")]
        public string Id { get; set; }

        /// <summary>
        /// Wikipedia link to circuit info.
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }

        /// <summary>
        /// Circuit Name.
        /// </summary>
        [JsonProperty("circuitName")]
        public string Name { get; set; }

        /// <summary>
        /// Circuit Location in coordinates.
        /// <seealso cref="Location"/>
        /// </summary>
        [JsonProperty("Location")]
        public Location Location { get; set; }

        /// <summary>
        /// Get automatically the Google Maps URI.
        /// </summary>
        public string GoogleMapsURI { get { return String.Format("https://www.google.com/maps/search/?api=1&query={0},{1}", Location.Latitud, Location.Longitud); } }
    }
}
