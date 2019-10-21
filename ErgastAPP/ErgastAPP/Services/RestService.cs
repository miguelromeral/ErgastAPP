using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ErgastAPP.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ErgastAPP.Services
{
    /// <summary>
    /// Performs the request to the Ergast API.
    /// </summary>
    public class RestService
    {
        /// <summary>
        /// HTTP Client to performs the request.
        /// </summary>
        HttpClient _client;
        /// <summary>
        /// API request URI Builder.
        /// </summary>
        ErgastAPI _api;

        /// <summary>
        /// Main Constructor.
        /// </summary>
        public RestService()
        {
            _client = new HttpClient();
            // Added 200 seconds of limit due to the Evolution (laps data) amount of packages to be retrieved.
            _client.Timeout = TimeSpan.FromSeconds(200);
            _api = new ErgastAPI();
        }

        /// <summary>
        /// Retrieves all seasons data.
        /// </summary>
        /// <returns>All seasons data.</returns>
        public async Task<DataErgastSeasons> GetSeasonsDataAsync()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.Seasons());
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastSeasons>(DataErgast.RemoveMRData(content));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Get the last race data.
        /// </summary>
        /// <returns>Last race data.</returns>
        public async Task<Race> GetLastRaceAsync()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.LastRace());
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastRaces>(DataErgast.RemoveMRData(content))?.RaceTable?.Races[0];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Get all races in a year.
        /// </summary>
        /// <param name="year">Year of the season.</param>
        /// <returns>All races in a year.</returns>
        public async Task<RaceTable> GetRacesBySeasonAsync(int year)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.RacesBySeason(year));
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

        /// <summary>
        /// Gets all races starting by the offset.
        /// </summary>
        /// <param name="offset">Offset to begin counting.</param>
        /// <returns>All races starting in the offset.</returns>
        private async Task<RaceTable> GetRacesByURIAsync(int offset)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.Races(offset));
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

        /// <summary>
        /// Gets all races in History.
        /// </summary>
        /// <returns>All races in History.</returns>
        public async Task<RaceTable> GetRacesAsync()
        {
            var r1 = await GetRacesByURIAsync(0);
            var r2 = await GetRacesByURIAsync(_api.limit);

            foreach(var r in r2.Races)
            {
                r1.Races.Add(r);
            }
            return r1;
        }

        /// <summary>
        /// Gets drivers info. It can be filtered by year and round.
        /// </summary>
        /// <param name="year">Drivers of this year.</param>
        /// <param name="round">Drivers of this round that year.</param>
        /// <returns></returns>
        public async Task<DriverTable> GetDriversAsync(int? year = null, int? round = null)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.Drivers(year, round));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastDrivers>(DataErgast.RemoveMRData(content))?.DriverTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Gets all circuits info. It can be filtered by year.
        /// </summary>
        /// <param name="year">Year to be filtered.</param>
        /// <returns>All circuits info.</returns>
        public async Task<CircuitTable> GetCircuitsAsync(int? year = null)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.Circuits(year));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastCircuits>(DataErgast.RemoveMRData(content))?.CircuitTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Gets driver info given its ID.
        /// </summary>
        /// <param name="driverId">Driver ID.</param>
        /// <returns>Driver data.</returns>
        public async Task<DriverTable> GetDriverInfoAsync(string driverId)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.Drivers(driverId));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastDrivers>(DataErgast.RemoveMRData(content))?.DriverTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Gets constructor list.
        /// </summary>
        /// <returns>Constructors info.</returns>
        public async Task<ConstructorTable> GetConstructorsAsync()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.Constructors());
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastConstructors>(DataErgast.RemoveMRData(content))?.ConstructorTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Gets race results given the year and round of the race.
        /// </summary>
        /// <param name="year">Year of the race.</param>
        /// <param name="round">Round of the season.</param>
        /// <returns>Race results info.</returns>
        public async Task<RaceTable> GetRaceResultsAsync(int year, int round)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.RaceResults(year, round));
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

        /// <summary>
        /// Gets all the seasons a specific driver has won the Driver WC.
        /// </summary>
        /// <param name="driver">Driver ID.</param>
        /// <returns>Seasons data.</returns>
        public async Task<SeasonTable> GetSeasonsDriverWorldChampionAsync(string driver)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.SeasonWorldChampionByDriver(driver));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastSeasons>(DataErgast.RemoveMRData(content))?.SeasonTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Gets all seasons a specific constructor has won the Constructor WC.
        /// </summary>
        /// <param name="constructor">Constructor ID.</param>
        /// <returns>Seasons data.</returns>
        public async Task<SeasonTable> GetSeasonsConstructorsWorldChampionAsync(string constructor)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.SeasonWorldChampionByConstructor(constructor));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastSeasons>(DataErgast.RemoveMRData(content))?.SeasonTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Gets race results given the year and round of the race.
        /// </summary>
        /// <param name="year">Year of the race.</param>
        /// <param name="round">Round of the season.</param>
        /// <returns>Race data with results provided.</returns>
        public async Task<Race> ResultsByRaceAsync(int year, int round)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.RaceResults(year, round));
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

        /// <summary>
        /// Gets qualifying results given the year and round of the race.
        /// </summary>
        /// <param name="year">Year of the race.</param>
        /// <param name="round">Round of the season.</param>
        /// <returns>Race data with qualifying provided.</returns>
        public async Task<Race> QualifyingByRaceAsync(int year, int round)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.QualifyingByRace(year, round));
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

        /// <summary>
        /// Gets driver standings for all seasons.
        /// </summary>
        /// <returns>Driver Standings info.</returns>
        public async Task<StandingsTable> DriverStandingsBySeason()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.ChampionsByYear());
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastStandings>(DataErgast.RemoveMRData(content))?.StandingsTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Gets constructor standings for all seasons.
        /// </summary>
        /// <returns>Constructor Standings info.</returns>
        public async Task<StandingsTable> ConstructorStandingsBySeason()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.ChampionsByYearConstrcutor());
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

        /// <summary>
        /// Gets driver standings at the end of the race.
        /// </summary>
        /// <param name="year">Year of the race.</param>
        /// <param name="round">Round of the season.</param>
        /// <returns>Driver standings info.</returns>
        public async Task<StandingsTable> DriverStandingsByRace(int year, int round)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.DriverStandingsByRace(year, round));
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

        /// <summary>
        /// Gets constructor standings at the end of a race.
        /// </summary>
        /// <param name="year">Year of the race.</param>
        /// <param name="round">Round of the season.</param>
        /// <returns>Constructor standings info.</returns>
        public async Task<StandingsTable> ConstructorStandingsByRace(int year, int round)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.ConstructorStandingsByRace(year, round));
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

        /// <summary>
        /// Gets all races that a Driver has been into.
        /// </summary>
        /// <param name="driver">Driver ID.</param>
        /// <returns>Race list info.</returns>
        public async Task<RaceTable> RacesByDriverAsync(string driver)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.RacesByDriver(driver));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var aux = JsonConvert.DeserializeObject<DataErgastRaces>(DataErgast.RemoveMRData(content));
                    if (aux != null)
                        return aux.RaceTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Gets list of races a constructor has been into, starting by the offset.
        /// </summary>
        /// <param name="constructor">Constructor ID.</param>
        /// <param name="offset">Offset to start in.</param>
        /// <returns>Races info.</returns>
        private async Task<RaceTable> RacesByConstructorFragmentAsync(string constructor, int offset)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.RacesByConstructor(constructor, offset));
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

        /// <summary>
        /// Gets all list of race a constructor has been into.
        /// </summary>
        /// <param name="constructor">Constructor ID.</param>
        /// <returns>List of races info.</returns>
        public async Task<RaceTable> GetRacesByConstructorAsync(string constructor)
        {
            var r1 = await RacesByConstructorFragmentAsync(constructor, 0);
            var r2 = await RacesByConstructorFragmentAsync(constructor, _api.limit);
            //var r3 = await RacesByConstructorFragmentAsync(constructor, _api.limit * 2);

            foreach (var r in r2.Races)
            {
                r1.Races.Add(r);
            }
            //foreach (var r in r3.Races)
            //{
            //    r1.Races.Add(r);
            //}
            return r1;
        }
        
        /// <summary>
        /// Gets all constructors a driver has been along his career.
        /// </summary>
        /// <param name="driver">Driver ID.</param>
        /// <returns>Constructors info.</returns>
        public async Task<ConstructorTable> ConstructorsByDriverAsync(string driver)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.ConstructorsByDriver(driver));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastConstructors>(DataErgast.RemoveMRData(content))?.ConstructorTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Gets all races a driver has set a fastest lap.
        /// </summary>
        /// <param name="driver">Driver ID.</param>
        /// <returns>Races info.</returns>
        public async Task<RaceTable> FastestLapsByDriverAsync(string driver)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.FastestLapsByDriver(driver));
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

        /// <summary>
        /// Gets all races a constructors has set a fastest lap.
        /// </summary>
        /// <param name="constructor">Constructor ID.</param>
        /// <returns>Races info.</returns>
        public async Task<RaceTable> FastestLapsByConstructorAsync(string constructor)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.FastestLapsByConstructor(constructor));
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

        /// <summary>
        /// Gets all laps set by a driver in a race.
        /// </summary>
        /// <param name="year">Year of the race.</param>
        /// <param name="round">Round of the season.</param>
        /// <param name="driver">Driver ID.</param>
        /// <returns>All laps info.</returns>
        public async Task<Race> LapsByRaceAndDriverAsync(int year, int round, string driver)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.LapsByRaceAndDriver(year, round, driver));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastRaces>(DataErgast.RemoveMRData(content))?.RaceTable?.Races[0];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Gets all pit stops set by a driver in a race.
        /// </summary>
        /// <param name="year">Year of the race.</param>
        /// <param name="round">Round of the season.</param>
        /// <param name="driver">Driver ID.</param>
        /// <returns>All pit stops info.</returns>
        public async Task<Race> PitStopsByRaceAndDriverAsync(int year, int round, string driver)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.PitStopsByRaceAndDriver(year, round, driver));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastRaces>(DataErgast.RemoveMRData(content))?.RaceTable?.Races[0];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Gets all drivers that has signed a specific constructor.
        /// </summary>
        /// <param name="constructor">Constructor ID.</param>
        /// <returns>Drivers info.</returns>
        public async Task<DriverTable> DriversByConstructorAsync(string constructor)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.DriversByConstructor(constructor));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastDrivers>(DataErgast.RemoveMRData(content))?.DriverTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Gets all races a circuit has held.
        /// </summary>
        /// <param name="circuit">Circuit ID.</param>
        /// <returns>Races info.</returns>
        public async Task<RaceTable> RacesByCircuit(string circuit)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.RacesByCircuit(circuit));
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

        /// <summary>
        /// Gets constructor info.
        /// </summary>
        /// <param name="constructor">Constructor ID.</param>
        /// <returns>Constructor info.</returns>
        public async Task<Constructor> GetConstructorAsync(string constructor)
        {
            string uri = _api.Constructor(constructor);
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastConstructors>(DataErgast.RemoveMRData(content))?.ConstructorTable.Constructors[0];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Gets all laps set in the whole race, starting in the offset.
        /// </summary>
        /// <param name="year">Year of the race.</param>
        /// <param name="round">Round of the season.</param>
        /// <param name="offset">Offset to start in.</param>
        /// <returns>Laps info.</returns>
        private async Task<Race> GetLapsByRace(int year, int round, int offset)
        {
            string uri = _api.LapsByRace(year, round, offset);
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

        /// <summary>
        /// Gets all laps set in the whole race.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="round"></param>
        /// <returns></returns>
        public async Task<Race> GetLapsByRace(int year, int round)
        {
            try
            {
                var l1 = await GetLapsByRace(year, round, 0);
                // We prevent not make another request if is not necessary.
                if (l1.Laps.Sum(x => x.Timings.Count) == _api.limit)
                {
                    Race l2 = await GetLapsByRace(year, round, _api.limit);
                    if (l2 != null)
                        foreach (var l in l2.Laps)
                        {
                            l1.Laps.Add(l);
                        }
                }
                
                return l1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Gets all seasons a driver has participated.
        /// </summary>
        /// <param name="driver">Driver ID.</param>
        /// <returns>Season info.</returns>
        public async Task<SeasonTable> GetSeasonsByDriverAsync(string driver)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.SeasonsByDriver(driver));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastSeasons>(DataErgast.RemoveMRData(content))?.SeasonTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Gets all drivers who has won at least once in this circuit.
        /// </summary>
        /// <param name="circuit">Circuit ID.</param>
        /// <returns>Drivers info.</returns>
        public async Task<DriverTable> GetDriversWinnerCircuitAsync(string circuit)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_api.DriversWinnersInCircuit(circuit));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DataErgastDrivers>(DataErgast.RemoveMRData(content))?.DriverTable;
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
