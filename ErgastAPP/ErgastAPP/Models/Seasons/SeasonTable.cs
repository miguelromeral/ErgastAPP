using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class SeasonTable
    {
        [JsonProperty("seasons")]
        public List<Season> Seasons { get; set; }
    }
}
