using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Constructor Table.
    /// 
    /// It allows to have a list of Constructors.
    /// </summary>
    public class ConstructorTable
    {
        /// <summary>
        /// Driver ID.
        /// When the constructors are for a specified driver.
        /// </summary>
        [JsonProperty("driverId")]
        public string DriverId { get; set; }
        
        /// <summary>
        /// List of Constructors.
        /// <seealso cref="Constructor"/>
        /// </summary>
        [JsonProperty("Constructors")]
        public List<Constructor> Constructors { get; set; }
    }
}
