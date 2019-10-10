using ErgastAPP.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ErgastAPP.Models
{
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

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        public string Flag { get { return Images.FlagByNationality(Nationality); } }

        [JsonProperty("permanentNumber")]
        public int Number { get; set; }

        public string PrettyNumber { get { return (Number == 0 ? "-" : Number.ToString()); } }

        [JsonProperty("code")]
        public string Code { get; set; }

        public string PrettyCode { get { return (String.IsNullOrEmpty(Code) ? "-" : Code); } }

        public string Fullname { get { return GivenName + " " + FamilyName.ToUpper(); } }
    }
}
