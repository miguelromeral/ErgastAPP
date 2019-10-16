using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Race info.
    /// </summary>
    public class Race
    {
        /// <summary>
        /// Year when the race was celebrated.
        /// </summary>
        [JsonProperty("season")]
        public int Season { get; set; }

        /// <summary>
        /// Number of race in that year.
        /// </summary>
        [JsonProperty("round")]
        public int Round { get; set; }

        /// <summary>
        /// Wikipedia URL with the race report.
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }

        /// <summary>
        /// Race name.
        /// </summary>
        [JsonProperty("raceName")]
        public string Name { get; set; }

        /// <summary>
        /// Circuit that host the Grand Prix.
        /// <seealso cref="Circuit"/>
        /// </summary>
        [JsonProperty("Circuit")]
        public Circuit Circuit { get; set; }

        /// <summary>
        /// Date when the GP was celebrated in yyyy-MM-dd format.
        /// </summary>
        [JsonProperty("date")]
        public string Date { get; set; }

        /// <summary>
        /// Local Time for the begining of the race.
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }

        /// <summary>
        /// List of all results for this race.
        /// <seealso cref="Result"/>
        /// </summary>
        [JsonProperty("Results")]
        public List<Result> Results { get; set; }

        /// <summary>
        /// List of all qualifying result for this race.
        /// <seealso cref="Qualifying"/>
        /// </summary>
        [JsonProperty("QualifyingResults")]
        public List<Qualifying> Qualifying { get; set; }

        /// <summary>
        /// List of all laps that the drivers set in the race.
        /// <seealso cref="Lap"/>
        /// </summary>
        [JsonProperty("Laps")]
        public List<Lap> Laps { get; set; }

        /// <summary>
        /// List of all pit stops that the race had.
        /// <seealso cref="PitStop"/>
        /// </summary>
        [JsonProperty("PitStops")]
        public List<PitStop> PitStops { get; set; }

        /// <summary>
        /// Gets the race date with dd/MM/yyyy format.
        /// </summary>
        public string PrettyDate
        {
            get
            {
                if (String.IsNullOrWhiteSpace(Date))
                    return "";

                var sp = Date.Split('-');
                return new DateTime(Convert.ToInt32(sp[0]), Convert.ToInt32(sp[1]), Convert.ToInt32(sp[2])).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Race winner result.
        /// <seealso cref="Result"/>
        /// </summary>
        public Result Winner { get { return Results?.Where(x => x.Position == 1).FirstOrDefault(); } }

        /// <summary>
        /// Second driver in the race result. 
        /// <seealso cref="Result"/>
        /// </summary>
        public Result Second { get { return Results?.Where(x => x.Position == 2).FirstOrDefault(); } }

        /// <summary>
        /// Third driver in the race result.
        /// <seealso cref="Result"/>
        /// </summary>
        public Result Third { get { return Results?.Where(x => x.Position == 3).FirstOrDefault(); } }

        /// <summary>
        /// First qualifyied in the race.
        /// <seealso cref="Qualifying"/>
        /// </summary>
        public Qualifying Qualy_First { get { return Qualifying?.Where(x => x.Position == 1).FirstOrDefault(); } }

        /// <summary>
        /// Second qualifyied in the race.
        /// <seealso cref="Qualifying"/>
        /// </summary>
        public Qualifying Qualy_Second { get { return Qualifying?.Where(x => x.Position == 2).FirstOrDefault(); } }

        /// <summary>
        /// Third qualifyed in the race.
        /// <seealso cref="Qualifying"/>
        /// </summary>
        public Qualifying Qualy_Third { get { return Qualifying?.Where(x => x.Position == 3).FirstOrDefault(); } }

        /// <summary>
        /// Result of the fastest lap in the race.
        /// <seealso cref="Result"/>
        /// </summary>
        public Result FastestLap { get { return Results?.Where(x => x.FastestLap != null && x.FastestLap.Rank == 1).FirstOrDefault(); } }

        /// <summary>
        /// Number of the list.
        /// </summary>
        public int Number { get; set; }
    }
}
