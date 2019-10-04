using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class ErgastAPI
    {
        public static string URL = "https://ergast.com/api/f1";
        //public bool json = true;
        public int limit = 10000;

        private string _json = ".json";
        private string _seasons = "/seasons";

        public string Seasons
        {
            get
            {
                return URL + _seasons + _json + "?" + AddLimit();
            }
        }
        
        private string AddLimit()
        {
            return "limit=" + limit;
        }
    }
}
