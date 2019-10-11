using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class ErgastAPI
    {
        public static string URL = "https://ergast.com/api/f1";
        public int limit = 1000;

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


        #region SEASONS
        public string Seasons
        {
            get
            {
                return URL + _seasons + _json + "?" + AddLimit();
            }
        }
        
        public string SeasonByYear(int year)
        {
            return URL + "/" + year + _seasons + _json;
        }
        public string SeasonWorldChampionByYear(int year)
        {
            return URL + year + _driverStandings + "/1" + _json;
        }
        #endregion

        private string AddLimit()
        {
            if (limit == 0)
                return "";

            return "limit=" + limit;
        }
        private string AddOffset(int offset)
        {
            return "offset=" + offset;
        }

        #region RACES
        public string RacesPt1()
        {
            return URL + _races + _json + "?" + AddLimit();
        }
        public string RacesPt2()
        {
            return URL + _races + _json + "?" + AddLimit() + "&" + AddOffset(limit);
        }
        public string RacesBySeason(int year)
        {
            return URL + "/" + year + _json + "?" + AddLimit();
        }
        public string RaceByDriverPosition(string driver, int position)
        {
            return URL + _drivers + "/" + driver + _results + "/" + position + _json + "?" + AddLimit();
        }
        #endregion

        #region DRIVERS
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

        public string Drivers(string driverId)
        {
            return URL + _drivers + "/" + driverId + _json;
        }

        public string SeasonWorldChampionByDriver(string driver)
        {
            return URL + _drivers + "/" + driver + _driverStandings + "/1" + _seasons + _json;
        }
        #endregion

        #region CONSTRUCTORS
        public string Constructors { get { return URL + _constructors + _json + "?" + AddLimit(); } }

        public string ConstructorsByDriver(string driver) { return URL + _drivers + "/" + driver + _constructors + _json + "?" + AddLimit(); }

        #endregion

        #region CIRCUITS
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
        public string FastestLapsByDriver(string driver)
        {
            return URL + _drivers + "/" + driver + _fastest + "/1" + _results + _json + "?" + AddLimit();
        }
        

        #endregion


        #region QUALIFYING
        public string QualifyingByRace(int year, int round)
        {
            return URL + "/" + year + "/" + round + _qualifying + _json + "?" + AddLimit();
        }
        #endregion

        #region STANDINGS
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
    }
}
