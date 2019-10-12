using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class DriverTable
    {
        [JsonProperty("constructorId")]
        public string ConstructorId { get; set; }

        [JsonProperty("Drivers")]
        public List<Driver> Drivers { get; set; }
    }
}
