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
