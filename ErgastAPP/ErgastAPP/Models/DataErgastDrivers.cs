using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class DataErgastDrivers : DataErgast
    {
        [JsonProperty("DriverTable")]
        public DriverTable DriverTable { get; set; }
    }

    public class DriverTable
    {
        [JsonProperty("Drivers")]
        public List<Driver> Drivers { get; set; }
    }

    public class Driver
    {
        [JsonProperty("driverId")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
        
        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("familyName")]
        public string FamilyName { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        public string Fullname { get { return GivenName + " " + FamilyName; } }
    }
}
