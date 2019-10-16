using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Response for drivers request.
    /// <seealso cref="DataErgast"/>
    /// </summary>
    public class DataErgastDrivers : DataErgast
    {
        /// <summary>
        /// Driver info.
        /// <seealso cref="DriverTable"/>
        /// </summary>
        [JsonProperty("DriverTable")]
        public DriverTable DriverTable { get; set; }
    }
}
