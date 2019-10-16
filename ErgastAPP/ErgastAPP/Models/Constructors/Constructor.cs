using ErgastAPP.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Constructor Model.
    /// <see cref="https://ergast.com/mrd/methods/constructors/"/>
    /// </summary>
    public class Constructor
    {
        /// <summary>
        /// Constructor PK.
        /// </summary>
        [JsonProperty("constructorId")]
        public string Id { get; set; }

        /// <summary>
        /// Wikipedia URL for constructor.
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }

        /// <summary>
        /// Constructor Name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Constructor Nationality.
        /// </summary>
        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        /// <summary>
        /// Wikipedia URL for the flag of its nationality.
        /// </summary>
        public string Flag { get { return Images.FlagByNationality(Nationality); } }
    }
}
