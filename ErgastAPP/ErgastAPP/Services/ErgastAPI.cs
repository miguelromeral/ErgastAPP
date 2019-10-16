using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Generates API REST URL to be called by the service.
    /// <see cref="https://ergast.com/mrd/"/>
    /// </summary>
    public class ErgastAPI
    {
        /// <summary>
        /// Main URL of the API.
        /// </summary>
        public static string URL = "https://ergast.com/api/f1";
        /// <summary>
        /// Limit of rows in each call. Established by the API.
        /// </summary>
        public int limit = 1000;


        /// <summary>
        /// Appends the limit of rows to be retrieved to the URL.
        /// </summary>
        /// <returns>String formatted param.</returns>
        private string AddLimit()
        {
            if (limit == 0)
                return "";

            return "limit=" + limit;
        }
        /// <summary>
        /// Appends the offset of rows to begin retrieving rows.
        /// </summary>
        /// <param name="offset">Number of the first N rows to be ignored.</param>
        /// <returns></returns>
        private string AddOffset(int offset)
        {
            return "offset=" + offset;
        }
        
        #region PATHS
        // Can be combined.
        private string _json = ".json";
        private string _seasons = "/seasons";
        private string _races = "/races";
        private string _drivers = "/drivers";
        private string _driverStandings = "/driverStandings";
        private string _constructorStandings = "/constructorStandings";
        private string _results = "/results";
        private string _constructors = "/constructors";
        private string _qualifying = "/qualifying";
        private string _fastest = "/fastest";
        private string _laps = "/laps";
        private string _current = "/current";
        private string _last = "/last";
        private string _pitstops = "/pitstops";
        private string _circuits = "/circuits";
        #endregion
        
        #region SEASONS

        /// <summary>
        /// Get all seasons.
        /// </summary>
        /// <returns>URL for the request</returns>
        public string Seasons()
        {
            return URL + _seasons + _json + "?" + AddLimit();
        }
        /// <summary>
        /// Gets a season info by the year provided.
        /// </summary>
        /// <param name="year">Year of the season</param>
        /// <returns>URL for the request</returns>
        public string SeasonByYear(int year)
        {
            return URL + "/" + year + _seasons + _json;
        }
        /// <summary>
        /// Gets the seasons which one driver have participated in.
        /// </summary>
        /// <param name="driver">Driver ID</param>
        /// <returns>URL to make the request</returns>
        public string SeasonsByDriver(string driver)
        {
            return URL + _drivers + "/" + driver + _seasons + _json + "?" + AddLimit();
        }
        /// <summary>
        /// Gets all the seasons filtering by the driver champion.
        /// </summary>
        /// <param name="driver">Driver ID</param>
        /// <returns>URL to make the request</returns>
        public string SeasonWorldChampionByDriver(string driver)
        {
            return URL + _drivers + "/" + driver + _driverStandings + "/1" + _seasons + _json;
        }
        /// <summary>
        /// Get the seasons when a constructor won the championship.
        /// </summary>
        /// <param name="constructor">Constructor ID</param>
        /// <returns>URL to make the request.</returns>
        public string SeasonWorldChampionByConstructor(string constructor)
        {
            return URL + _constructors + "/" + constructor + _constructorStandings + "/1" + _seasons + _json + "?" + AddLimit();
        }

        #endregion

        #region RACES
        /// <summary>
        /// Gets the last race info.
        /// </summary>
        /// <returns>URL to make the request</returns>
        public string LastRace()
        {
            return URL + _current + _last + _json;
        }

        /// <summary>
        /// Gets all the races until the limit.
        /// </summary>
        /// <param name="offset">Offset of the URL</param>
        /// <returns>URL to make the request</returns>
        public string Races(int offset)
        {
            return URL + _races + _json + "?" + AddLimit() + "&" + AddOffset(offset);
        }
        /// <summary>
        /// Gets all the races for a specific season.
        /// </summary>
        /// <param name="year">Year of the season.</param>
        /// <returns>URL to make the request</returns>
        public string RacesBySeason(int year)
        {
            return URL + "/" + year + _json + "?" + AddLimit();
        }
        /// <summary>
        /// Gets all the races a driver has been on an specific position.
        /// </summary>
        /// <param name="driver">Driver ID</param>
        /// <param name="position">Position to be searched</param>
        /// <returns>URL to make the request</returns>
        public string RaceByDriverPosition(string driver, int position)
        {
            return URL + _drivers + "/" + driver + _results + "/" + position + _json + "?" + AddLimit();
        }
        /// <summary>
        /// Gets the races for a same circuit.
        /// </summary>
        /// <param name="circuit">Circuit ID</param>
        /// <returns>URL to make the request</returns>
        public string RacesByCircuit(string circuit)
        {
            return URL + _circuits + "/" + circuit + _races + _json + "?" + AddLimit();
        }
        #endregion

        #region DRIVERS
        /// <summary>
        /// Drivers that have been in, at least, one race. It can be filtered by year and round.
        /// </summary>
        /// <param name="year">Season year</param>
        /// <param name="round">Season round</param>
        /// <returns>URL to make the request</returns>
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
        /// <summary>
        /// Get Driver info based upon the Driver ID.
        /// </summary>
        /// <param name="driverId">Driver ID</param>
        /// <returns>URL to make the request</returns>
        public string Drivers(string driverId)
        {
            return URL + _drivers + "/" + driverId + _json;
        }
        /// <summary>
        /// Get the drivers that have been in a constructor.
        /// </summary>
        /// <param name="constructor">Constructor ID</param>
        /// <returns>URL to make the request.</returns>
        public string DriversByConstructor(string constructor)
        {
            return URL + _constructors + "/" + constructor + _drivers + _json + "?" + AddLimit();
        }
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Get all constructors.
        /// </summary>
        /// <returns>URL to make the request</returns>
        public string Constructors()
        {
            return URL + _constructors + _json + "?" + AddLimit();
        }
        /// <summary>
        /// Gets the constructors of a driver.
        /// </summary>
        /// <param name="driver">Driver ID</param>
        /// <returns>URL to make the request</returns>
        public string ConstructorsByDriver(string driver)
        {
            return URL + _drivers + "/" + driver + _constructors + _json + "?" + AddLimit();
        }
        /// <summary>
        /// Gets the constructor info by its ID
        /// </summary>
        /// <param name="cons">Constructor ID</param>
        /// <returns>URL to make the request</returns>
        public string Constructor(string cons) { return URL + _constructors + "/" + cons + _json; }

        #endregion

        #region CIRCUITS
        /// <summary>
        /// Gets all the circuits.
        /// </summary>
        /// <param name="year">Year to filter the circuits</param>
        /// <returns>URL to make the request</returns>
        public string Circuits(int? year = null)
        {
            string extra = "";

            if (year != null)
            {
                extra += year + "/";
            }

            return URL + "/" + extra + "circuits" + _json + "?" + AddLimit();
        }
        #endregion

        #region RESULTS
        public string RaceResults(int year, int round)
        {
            return URL + "/" + year + "/" + round + _results + _json + "?" + AddLimit();
        }

        public string RacesByDriver(string driver)
        {
            return URL + _drivers + "/" + driver + _results + _json + "?" + AddLimit();
        }
        public string RacesByConstructor(string constructor, int offset)
        {
            return URL + _constructors + "/" + constructor + _results + _json + "?" + AddLimit() + "&" + AddOffset(offset);
        }
        public string FastestLapsByDriver(string driver)
        {
            return URL + _drivers + "/" + driver + _fastest + "/1" + _results + _json + "?" + AddLimit();
        }

        public string FastestLapsByConstructor(string constructor)
        {
            return URL + _constructors + "/" + constructor + _fastest + "/1" + _results + _json + "?" + AddLimit();
        }


        #endregion

        #region QUALIFYING
        public string QualifyingByRace(int year, int round)
        {
            return URL + "/" + year + "/" + round + _qualifying + _json + "?" + AddLimit();
        }
        #endregion

        #region STANDINGS
        public string SeasonWorldChampionByYear(int year)
        {
            return URL + year + _driverStandings + "/1" + _json;
        }

        public string ChampionsByYear()
        {
            return URL + _driverStandings + "/1" + _json + "?" + AddLimit();
        }

        public string ChampionsByYearConstrcutor()
        {
            return URL + _constructorStandings + "/1" + _json + "?" + AddLimit();
        }
        public string DriverStandingsByRace(int year, int round)
        {
            return URL + "/" + year + "/" + round + _driverStandings + _json + "?" + AddLimit();
        }

        public string ConstructorStandingsByRace(int year, int round)
        {
            return URL + "/" + year + "/" + round + _constructorStandings + _json + "?" + AddLimit();
        }
        #endregion

        #region LAPS
        public string LapsByRaceAndDriver(int year, int round, string driver)
        {
            return URL + "/" + year + "/" + round + _drivers + "/" + driver + _laps + _json + "?" + AddLimit();
        }

        public string LapsByRace(int year, int round, int offset)
        {
            return URL + "/" + year + "/" + round + _laps + _json + "?" + AddLimit() + "&" + AddOffset(offset);
        }
        #endregion

        #region PIT STOPS
        public string PitStopsByRaceAndDriver(int year, int round, string driver)
        {
            return URL + "/" + year + "/" + round + _drivers + "/" + driver + _pitstops + _json + "?" + AddLimit();
        }
        #endregion
    }
}
