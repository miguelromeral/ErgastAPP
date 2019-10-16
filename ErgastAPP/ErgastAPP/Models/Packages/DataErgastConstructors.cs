using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Response for a constructor request.
    /// <seealso cref="DataErgast"/>
    /// </summary>
    public class DataErgastConstructors : DataErgast
    {
        /// <summary>
        /// Constructor info.
        /// <seealso cref="ConstructorTable"/>
        /// </summary>
        [JsonProperty("ConstructorTable")]
        public ConstructorTable ConstructorTable { get; set; }
    }
}
