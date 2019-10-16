using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Main package.
    /// Every response will have this format.
    /// </summary>
    public class DataErgast
    {
        /// <summary>
        /// XMLNS response file.
        /// Contains a URL with the data format.
        /// </summary>
        [JsonProperty("xmlns")]
        public string XMLNS { get; set; }

        /// <summary>
        /// Motorsports series. Will ever be "f1"
        /// </summary>
        [JsonProperty("series")]
        public string Series { get; set; }

        /// <summary>
        /// URL requested by the client.
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }

        /// <summary>
        /// Limit of items retrieved.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Number of items the search will begin in.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Total number of items for this request.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Removes the first value.
        /// Every response has a root element "MRData" and then a package with this
        /// format. We remove this element in order to be able to parse every response.
        /// </summary>
        /// <param name="content">Raw string with the all response.</param>
        /// <returns>The raw string response without the MRData as root node.</returns>
        public static string RemoveMRData(string content)
        {
            JObject raw = JObject.Parse(content);

            foreach (var jprop in raw)
            {
                // We only need the value of the only duple we have.
                return JsonConvert.SerializeObject(jprop.Value);
            }
            return "";
        }
    }
}
