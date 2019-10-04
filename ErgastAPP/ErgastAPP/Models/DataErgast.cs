using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class DataErgast
    {
        [JsonProperty("MRData")]
        public string MRData { get; set; }
    }
}
