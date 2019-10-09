using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ErgastAPP.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ErgastAPP.Services
{
    public class RestService
    {
        HttpClient _client;
        ErgastAPI _api;

        public RestService()
        {
            _client = new HttpClient();
            _api = new ErgastAPI();
        }

        public async Task<DataErgastSeasons> GetSeasonsDataAsync()
        {
            string uri = _api.Seasons;
            DataErgastSeasons data = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<DataErgastSeasons>(DataErgast.RemoveMRData(content));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return data;
        }

        public async Task<DataErgastRaces> GetRacesBySeasonAsync(int year)
        {
            string uri = _api.RacesBySeason(year);
            DataErgastRaces data = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<DataErgastRaces>(DataErgast.RemoveMRData(content));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return data;
        }

        public async Task<DataErgastDrivers> GetDriversAsync(int? year = null, int? round = null)
        {
            string uri = _api.Drivers(year, round);
            DataErgastDrivers data = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<DataErgastDrivers>(DataErgast.RemoveMRData(content));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return data;
        }

        public async Task<DataErgastCircuits> GetCircuitsAsync(int? year = null)
        {
            string uri = _api.Circuits(year);
            DataErgastCircuits data = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<DataErgastCircuits>(DataErgast.RemoveMRData(content));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return data;
        }


        public async Task<DataErgastDrivers> GetDriverInfoAsync(string driverId)
        {
            string uri = _api.Drivers(driverId);
            DataErgastDrivers data = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<DataErgastDrivers>(DataErgast.RemoveMRData(content));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return data;
        }

        public async Task<DataErgastConstructors> GetConstructorsAsync()
        {
            string uri = _api.Constructors;
            DataErgastConstructors data = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<DataErgastConstructors>(DataErgast.RemoveMRData(content));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return data;
        }


        public async Task<DataErgastRaces> GetRaceResultsAsync(int year, int round)
        {
            string uri = _api.RaceResults(year, round);
            DataErgastRaces data = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<DataErgastRaces>(DataErgast.RemoveMRData(content));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return data;
        }


        public async Task<DataErgastSeasons> GetSeasonsDriverWorldChampionAsync(string driver)
        {
            string uri = _api.SeasonWorldChampionByDriver(driver);
            DataErgastSeasons data = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<DataErgastSeasons>(DataErgast.RemoveMRData(content));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return data;
        }

        public async Task<DriverStandings> GetSeasonsDriverWorldChampionAsync(int year)
        {
            string uri = _api.SeasonWorldChampionByYear(year);
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var aux = JsonConvert.DeserializeObject<DataErgastStandings>(DataErgast.RemoveMRData(content));
                    return null;
                    //if (aux != null)
                    //    return aux.StandingsTable.Standings[0].DriverStandings[0];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }


        public async Task<RaceTable> RacesByDriverPositionAsync(string driver, int position)
        {
            string uri = _api.RaceByDriverPosition(driver, position);
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastRaces>(DataErgast.RemoveMRData(content))?.RaceTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }


        public async Task<Race> ResultsByRaceAsync(int year, int round)
        {
            string uri = _api.ResultsByRace(year, round);
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastRaces>(DataErgast.RemoveMRData(content))?.RaceTable.Races[0];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }


        public async Task<Race> QualifyingByRaceAsync(int year, int round)
        {
            string uri = _api.QualifyingByRace(year, round);
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastRaces>(DataErgast.RemoveMRData(content))?.RaceTable.Races[0];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }

        public async Task<StandingsTable> DriverStandingsBySeason()
        {
            string uri = _api.ChampionsByYear();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var aux = JsonConvert.DeserializeObject<DataErgastStandings>(DataErgast.RemoveMRData(content));
                    if (aux != null)
                        return aux.StandingsTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }

        public async Task<StandingsTable> ConstructorStandingsBySeason()
        {
            string uri = _api.ChampionsByYearConstrcutor();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var aux = JsonConvert.DeserializeObject<DataErgastStandings>(DataErgast.RemoveMRData(content));
                    if (aux != null)
                        return aux.StandingsTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }


        public async Task<StandingsTable> DriverStandingsByRace(int year, int round)
        {
            string uri = _api.DriverStandingsByRace(year, round);
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var aux = JsonConvert.DeserializeObject<DataErgastStandings>(DataErgast.RemoveMRData(content));
                    if (aux != null)
                        return aux.StandingsTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }
        public async Task<StandingsTable> ConstructorStandingsByRace(int year, int round)
        {
            string uri = _api.ConstructorStandingsByRace(year, round);
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var aux = JsonConvert.DeserializeObject<DataErgastStandings>(DataErgast.RemoveMRData(content));
                    if (aux != null)
                        return aux.StandingsTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }
    }
}
