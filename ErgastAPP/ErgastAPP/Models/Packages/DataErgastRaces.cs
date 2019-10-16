using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ErgastAPP.Models
{
	public class DataErgastRaces : DataErgast
    {
        [JsonProperty("RaceTable")]
        public RaceTable RaceTable { get; set; }
    }
}