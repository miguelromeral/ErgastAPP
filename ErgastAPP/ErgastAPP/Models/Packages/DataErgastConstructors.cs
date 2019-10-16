using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class DataErgastConstructors : DataErgast
    {
        [JsonProperty("ConstructorTable")]
        public ConstructorTable ConstructorTable { get; set; }
    }
}
