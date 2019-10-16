using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Standings Table.
    /// </summary>
    public class Standings
    {
        /// <summary>
        /// Year of the season.
        /// </summary>
        [JsonProperty("season")]
        public int Season { get; set; }

        /// <summary>
        /// Round of the season.
        /// </summary>
        [JsonProperty("round")]
        public int Round { get; set; }

        /// <summary>
        /// List of drivers standings.
        /// <seealso cref="DriverStandings"/>
        /// </summary>
        [JsonProperty("DriverStandings")]
        public List<DriverStandings> DriverStandings { get; set; }
        
        /// <summary>
        /// List of constructors standings.
        /// <seealso cref="ConstructorStandings"/>
        /// </summary>
        [JsonProperty("ConstructorStandings")]
        public List<ConstructorStandings> ConstructorStandings { get; set; }

        /// <summary>
        /// Constructor of the Driver Champion.
        /// </summary>
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

        /// <summary>
        /// Driver Champion.
        /// </summary>
        public Driver DriverChampion { get { return DriverStandings?.Where(x => x.Position == 1).FirstOrDefault()?.Driver; } }

        /// <summary>
        /// Constructor Champion.
        /// </summary>
        public Constructor ConstructorChampion { get { return ConstructorStandings?.Where(x => x.Position == 1).FirstOrDefault()?.Constructor; } }

        /// <summary>
        /// Formats the double points to string. Avoids to have many zeros at the right.
        /// </summary>
        /// <param name="myNumber">Double number to be parsed.</param>
        /// <returns>String with the number and only decimals required.</returns>
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

