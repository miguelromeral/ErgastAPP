using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ErgastAPP.Models
{
    public class DataErgastDrivers : DataErgast
    {
        [JsonProperty("DriverTable")]
        public DriverTable DriverTable { get; set; }
    }
}
