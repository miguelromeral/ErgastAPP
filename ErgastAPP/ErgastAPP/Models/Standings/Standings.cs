using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErgastAPP.Models
{
    public class Standings
    {
        [JsonProperty("season")]
        public int Season { get; set; }

        [JsonProperty("round")]
        public int Round { get; set; }

        [JsonProperty("DriverStandings")]
        public List<DriverStandings> DriverStandings { get; set; }
        
        [JsonProperty("ConstructorStandings")]
        public List<ConstructorStandings> ConstructorStandings { get; set; }

        

        
        public Constructor DriverConstructorChampion
        {
            get
            {
                var aux = DriverStandings?.Where(x => x.Position == 1).FirstOrDefault();
                if (aux?.Constructor == null)
                    return null;

                return aux.Constructor[aux.Constructor.Count - 1];
            }
        }

        public Driver DriverChampion { get { return DriverStandings?.Where(x => x.Position == 1).FirstOrDefault()?.Driver; } }

        public Constructor ConstructorChampion { get { return ConstructorStandings?.Where(x => x.Position == 1).FirstOrDefault()?.Constructor; } }


        public static string DoFormat(double myNumber)
        {
            var s = string.Format("{0:0.0}", myNumber);

            if (s.EndsWith("0"))
            {
                return ((int)myNumber).ToString();
            }
            else
            {
                return s;
            }
        }
    }
}

