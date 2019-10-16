using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Season info.
    /// </summary>
    public class SeasonTable
    {
        /// <summary>
        /// List of seasons.
        /// </summary>
        [JsonProperty("seasons")]
        public List<Season> Seasons { get; set; }

        /// <summary>
        /// Indicates the number of the seasons with the list
        /// </summary>
        public string PrettySeasons
        {
            get
            {
                int count = Seasons.Count;
                string text = count.ToString();
                if(count != 0)
                {
                    string extra = "";
                    foreach(var i in Seasons)
                    {
                        extra += i.Year + ", ";
                    }
                    text += " (" + extra.Substring(0, extra.Length - 2) + ")";
                }
                return text;
            }
        }
    }
}
