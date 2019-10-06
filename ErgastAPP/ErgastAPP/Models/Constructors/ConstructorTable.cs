using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    public class ConstructorTable
    {
        [JsonProperty("Constructors")]
        public List<Constructor> Constructors { get; set; }
    }
}
