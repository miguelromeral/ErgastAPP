using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Response for races request.
    /// <seealso cref="DataErgast"/>
    /// </summary>
	public class DataErgastRaces : DataErgast
    {
        /// <summary>
        /// Race info.
        /// <seealso cref="RaceTable"/>
        /// </summary>
        [JsonProperty("RaceTable")]
        public RaceTable RaceTable { get; set; }
    }
}