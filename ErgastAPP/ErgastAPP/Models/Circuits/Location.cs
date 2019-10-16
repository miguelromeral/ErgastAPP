using ErgastAPP.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Location details for circuits.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Latitud.
        /// </summary>
        [JsonProperty("lat")]
        public string Latitud { get; set; }

        /// <summary>
        /// Longitud.
        /// </summary>
        [JsonProperty("long")]
        public string Longitud { get; set; }

        /// <summary>
        /// Locality of the track.
        /// </summary>
        [JsonProperty("locality")]
        public string Locality { get; set; }

        /// <summary>
        /// Country circuit.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Address Circuit.
        /// Displays the details in only one string.
        /// </summary>
        public string Address { get { return Country + ": " + Locality; } }

        /// <summary>
        /// Wikipedia URL with the flag of the country.
        /// </summary>
        public string Flag { get { return Images.FlagByCountry(Country); } }
    }
}
