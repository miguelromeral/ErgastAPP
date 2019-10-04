using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class DataErgastSeasons : DataErgast
    {
        [JsonProperty("SeasonTable")]
        public DataSeason SeasonTable { get; set; }
    }

    public class DataSeason
    {
        [JsonProperty("seasons")]
        public List<Season> Seasons { get; set; }
    }


    public class Season
    {
        [JsonProperty("season")]
        public string Year { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
