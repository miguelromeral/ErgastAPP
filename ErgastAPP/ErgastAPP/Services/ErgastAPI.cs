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
            if (limit == 0)
                return "";

            return "limit=" + limit;
        }

        public string RacesBySeason(int year)
        {
            return URL + "/" + year + _json + "?" + AddLimit();
        }

        public string Drivers(int? year = null, int? round = null)
        {
            string extra = "";

            if (year != null)
            {
                extra += year + "/";
                if (round != null)
                    extra += round + "/";
            }

            return URL + "/" + extra + "drivers" + _json + "?" + AddLimit();
        }

        public string Circuits(int? year = null)
        {
            string extra = "";

            if (year != null)
            {
                extra += year + "/";
            }

            return URL + "/" + extra + "circuits" + _json + "?" + AddLimit();
        }
    }
}
