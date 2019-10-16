using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Driver Table.
    /// Allows to have many drivers listed.
    /// </summary>
    public class DriverTable
    {
        /// <summary>
        /// Constructor ID.
        /// When looking for driver in an specific team.
        /// </summary>
        [JsonProperty("constructorId")]
        public string ConstructorId { get; set; }

        /// <summary>
        /// List of Drivers.
        /// <seealso cref="Driver"/>
        /// </summary>
        [JsonProperty("Drivers")]
        public List<Driver> Drivers { get; set; }
    }
}
