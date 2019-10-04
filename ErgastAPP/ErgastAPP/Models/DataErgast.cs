using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ErgastAPP.Models
{
    public class DataErgast
    {
        [JsonProperty("xmlns")]
        public string XMLNS { get; set; }

        [JsonProperty("series")]
        public string Series { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }


        public static string RemoveMRData(string content)
        {
            JObject raw = JObject.Parse(content);

            foreach (var jprop in raw)
            {
                return JsonConvert.SerializeObject(jprop.Value);
            }
            return "";
        }
    }
}
