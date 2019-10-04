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

    public class SeasonTable
    {
        [JsonProperty("seasons")]
        public List<Season> Seasons { get; set; }
    }


    public class Season
    {
        [JsonProperty("season")]
        public int Year { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
