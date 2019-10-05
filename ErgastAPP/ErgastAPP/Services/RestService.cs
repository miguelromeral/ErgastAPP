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
    }
}
