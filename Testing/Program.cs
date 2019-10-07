using ErgastAPP.Models;
using ErgastAPP.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prueba();


        }

        //public static async void Prueba()
        //{
        //    RestService _client = new RestSerivce();
        //    ErgastAPI _api = new ErgastAPI();

        //    string uri = _api.ChampionsByYear();
        //    try
        //    {
        //        HttpResponseMessage response = await _client.GetAsync(uri);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string content = await response.Content.ReadAsStringAsync();
        //            var aux = JsonConvert.DeserializeObject<DataErgastStandings>(DataErgast.RemoveMRData(content));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("\tERROR {0}", ex.Message);
        //    }
        //}
    }
}
