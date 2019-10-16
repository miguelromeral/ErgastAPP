using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class DataErgastSeasons : DataErgast
    {
        [JsonProperty("SeasonTable")]
        public SeasonTable SeasonTable { get; set; }
    }
}
