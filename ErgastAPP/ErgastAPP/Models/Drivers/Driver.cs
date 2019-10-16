using ErgastAPP.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ErgastAPP.Models
{
    /// <summary>
    /// Driver Model
    /// <see cref="https://ergast.com/mrd/methods/drivers/"/>
    /// </summary>
    public class Driver
    {
        /// <summary>
        /// Driver PK.
        /// </summary>
        [JsonProperty("driverId")]
        public string Id { get; set; }

        /// <summary>
        /// Wikipedia URL with the driver info.
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }

        /// <summary>
        /// Driver firstname.
        /// </summary>
        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        /// <summary>
        /// Driver lastname.
        /// </summary>
        [JsonProperty("familyName")]
        public string FamilyName { get; set; }

        /// <summary>
        /// Driver birthday with a yyyy-MM-dd format.
        /// </summary>
        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Driver birthday with a dd-MM-yyyy format.
        /// </summary>
        public string Birthday
        {
            get
            {
                if (String.IsNullOrWhiteSpace(DateOfBirth))
                    return "";

                var sp = DateOfBirth.Split('-');
                return new DateTime(Convert.ToInt32(sp[0]), Convert.ToInt32(sp[1]), Convert.ToInt32(sp[2])).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Driver Nationality.
        /// </summary>
        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        /// <summary>
        /// Wikipedia URL from flag depends on the nationality.
        /// </summary>
        public string Flag { get { return Images.FlagByNationality(Nationality); } }

        /// <summary>
        /// Permanent number.
        /// Since 2014, the drivers were allowed to choose their own number.
        /// </summary>
        [JsonProperty("permanentNumber")]
        public int Number { get; set; }

        /// <summary>
        /// Display the permanent driver in string.
        /// </summary>
        public string PrettyNumber { get { return (Number == 0 ? "-" : Number.ToString()); } }

        /// <summary>
        /// Three letters shortname
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// display the shortname in string..
        /// </summary>
        public string PrettyCode { get { return (String.IsNullOrEmpty(Code) ? "-" : Code); } }

        /// <summary>
        /// Driver Fullname.
        /// </summary>
        public string Fullname { get { return GivenName + " " + FamilyName.ToUpper(); } }
    }
}
