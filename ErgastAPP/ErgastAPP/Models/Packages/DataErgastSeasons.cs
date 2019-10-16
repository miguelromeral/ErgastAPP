using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Response for seasons request.
    /// <seealso cref="DataErgast"/>
    /// </summary>
    public class DataErgastSeasons : DataErgast
    {
        /// <summary>
        /// Seasons info.
        /// <seealso cref="SeasonTable"/>
        /// </summary>
        [JsonProperty("SeasonTable")]
        public SeasonTable SeasonTable { get; set; }
    }
}
