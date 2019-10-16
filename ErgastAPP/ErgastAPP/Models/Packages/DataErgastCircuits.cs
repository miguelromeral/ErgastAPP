using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Response for a circuit request.
    /// <seealso cref="DataErgast"/>
    /// </summary>
    public class DataErgastCircuits : DataErgast
    {
        /// <summary>
        /// Circuits info.
        /// <seealso cref="CircuitTable"/>
        /// </summary>
        [JsonProperty("CircuitTable")]
        public CircuitTable CircuitTable { get; set; }
    }
}
