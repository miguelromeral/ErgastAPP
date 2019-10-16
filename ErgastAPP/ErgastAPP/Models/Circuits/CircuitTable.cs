using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Circuit Table.
    /// Allows to have many circuit instances.
    /// </summary>
    public class CircuitTable
    {
        /// <summary>
        /// List of circuits
        /// <seealso cref="Circuit"/>
        /// </summary>
        [JsonProperty("Circuits")]
        public List<Circuit> Circuits { get; set; }
    }
}
