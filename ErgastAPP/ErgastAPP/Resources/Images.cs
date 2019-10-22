using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ErgastAPP.Resources
{
    /// <summary>
    /// Gets URL for images.
    /// </summary>
    public static class Images
    {
        #region FLAGS WIKIPEDIA
        // Unknown flag.
        private static string _unknown = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2a/Flag_of_None.svg/1280px-Flag_of_None.svg.png";

        // List of flags.
        private static string _australia = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/Flag_of_Australia_%28converted%29.svg/1920px-Flag_of_Australia_%28converted%29.svg.png";
        private static string _morocco = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/Flag_of_Morocco.svg/1280px-Flag_of_Morocco.svg.png";
        private static string _spain = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/Flag_of_Spain.svg/1280px-Flag_of_Spain.svg.png";
        private static string _UK = "https://upload.wikimedia.org/wikipedia/en/thumb/a/ae/Flag_of_the_United_Kingdom.svg/1920px-Flag_of_the_United_Kingdom.svg.png";
        private static string _USA = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/Flag_of_the_United_States.svg/1920px-Flag_of_the_United_States.svg.png";
        private static string _sweden = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4c/Flag_of_Sweden.svg/1280px-Flag_of_Sweden.svg.png";
        private static string _germany = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/ba/Flag_of_Germany.svg/1280px-Flag_of_Germany.svg.png";
        private static string _bahrain = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/Flag_of_Bahrain.svg/1280px-Flag_of_Bahrain.svg.png";
        private static string _azerbaijan = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Flag_of_Azerbaijan.svg/1920px-Flag_of_Azerbaijan.svg.png";
        private static string _portugal = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5c/Flag_of_Portugal.svg/1280px-Flag_of_Portugal.svg.png";
        private static string _switzerland = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/08/Flag_of_Switzerland_%28Pantone%29.svg/800px-Flag_of_Switzerland_%28Pantone%29.svg.png";
        private static string _india = "https://upload.wikimedia.org/wikipedia/en/thumb/4/41/Flag_of_India.svg/1280px-Flag_of_India.svg.png";
        private static string _france = "https://upload.wikimedia.org/wikipedia/en/thumb/c/c3/Flag_of_France.svg/1280px-Flag_of_France.svg.png";
        private static string _japan = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Flag_of_Japan.svg/1280px-Flag_of_Japan.svg.png";
        private static string _argentina = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1a/Flag_of_Argentina.svg/1280px-Flag_of_Argentina.svg.png";
        private static string _southafrica = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/af/Flag_of_South_Africa.svg/1280px-Flag_of_South_Africa.svg.png";
        private static string _vietnam = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/21/Flag_of_Vietnam.svg/1280px-Flag_of_Vietnam.svg.png";
        private static string _hungary = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Flag_of_Hungary.svg/1920px-Flag_of_Hungary.svg.png";
        private static string _italy = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/03/Flag_of_Italy.svg/1280px-Flag_of_Italy.svg.png";
        private static string _brazil = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/05/Flag_of_Brazil.svg/1280px-Flag_of_Brazil.svg.png";
        private static string _turkey = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Flag_of_Turkey.svg/1280px-Flag_of_Turkey.svg.png";
        private static string _singapore = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/48/Flag_of_Singapore.svg/1280px-Flag_of_Singapore.svg.png";
        private static string _monaco = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Flag_of_Monaco.svg/1024px-Flag_of_Monaco.svg.png";
        private static string _canada = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Flag_of_Canada_%28Pantone%29.svg/1920px-Flag_of_Canada_%28Pantone%29.svg.png";
        private static string _belgium = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/Flag_of_Belgium.svg/1024px-Flag_of_Belgium.svg.png";
        private static string _austria = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/41/Flag_of_Austria.svg/1280px-Flag_of_Austria.svg.png";
        private static string _mexico = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Flag_of_Mexico.svg/1920px-Flag_of_Mexico.svg.png";
        private static string _malaysia = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/66/Flag_of_Malaysia.svg/1920px-Flag_of_Malaysia.svg.png";
        private static string _china = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Flag_of_the_People%27s_Republic_of_China.svg/1280px-Flag_of_the_People%27s_Republic_of_China.svg.png";
        private static string _russia = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f3/Flag_of_Russia.svg/1280px-Flag_of_Russia.svg.png";
        private static string _UAE = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Flag_of_the_United_Arab_Emirates.svg/1920px-Flag_of_the_United_Arab_Emirates.svg.png";
        private static string _korea = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/09/Flag_of_South_Korea.svg/1280px-Flag_of_South_Korea.svg.png";
        private static string _netherlands = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Flag_of_the_Netherlands.svg/1280px-Flag_of_the_Netherlands.svg.png";
        #endregion


        #region FLAGS ANDROID
        // Android flags provided by: openmoji.org

        private static string a_unknown = "unknown.png";

        // List of flags.
        private static string a_australia = "australia.png";
        private static string a_morocco = "morocco.png";
        private static string a_spain = "spain";
        private static string a_UK = "greatbritain.png";
        private static string a_USA = "usa.png";
        private static string a_sweden = "sweden.png";
        private static string a_germany = "germany.png";
        private static string a_bahrain = "bahrain.png";
        private static string a_azerbaijan = "azerbaijan.png";
        private static string a_portugal = "portugal.png";
        private static string a_switzerland = "switzerland.png";
        private static string a_india = "india.png";
        private static string a_france = "france.png";
        private static string a_japan = "japan.png";
        private static string a_argentina = "argentina.png";
        private static string a_southafrica = "southafrica.png";
        private static string a_vietnam = "vietnam.png";
        private static string a_hungary = "hungary.png";
        private static string a_italy = "italy.png";
        private static string a_brazil = "brazil.png";
        private static string a_turkey = "turkey.png";
        private static string a_singapore = "singapore.png";
        private static string a_monaco = "monaco.png";
        private static string a_canada = "canada.png";
        private static string a_belgium = "belgium.png";
        private static string a_austria = "austria.png";
        private static string a_mexico = "mexico.png";
        private static string a_malaysia = "malaysa.png";
        private static string a_china = "china.png";
        private static string a_russia = "russia.png";
        private static string a_UAE = "uae.png";
        private static string a_korea = "korea.png";
        private static string a_netherlands = "netherlands.png";
        #endregion

        /// <summary>
        /// Gets the flag depends the country name.
        /// </summary>
        /// <param name="country"></param>
        /// <returns>Wikipedia URL flag.</returns>
        public static string FlagByCountry(string country)
        {
            if (Device.RuntimePlatform == Device.Android)
                return FlagByCountryAndroid(country);

            // IOS and UWP:
            switch (country)
            {
                case "Spain": return _spain;
                case "Australia": return _australia;
                case "Morocco": return _morocco;
                case "UK": return _UK;
                case "USA": return _USA;
                case "Sweden": return _sweden;
                case "Germany": return _germany;
                case "Bahrain": return _bahrain;
                case "Azerbaijan": return _azerbaijan;
                case "Portugal": return _portugal;
                case "Switzerland": return _switzerland;
                case "India": return _india;
                case "France": return _france;
                case "Japan": return _japan;
                case "Argentina": return _argentina;
                case "South Africa": return _southafrica;
                case "Vietnam": return _vietnam;
                case "Hungary": return _hungary;
                case "Italy": return _italy;
                case "Brazil": return _brazil;
                case "Turkey": return _turkey;
                case "Singapore": return _singapore;
                case "Monaco": return _monaco;
                case "Canada": return _canada;
                case "Belgium": return _belgium;
                case "Austria": return _austria;
                case "Mexico": return _mexico;
                case "Malaysia": return _malaysia;
                case "China": return _china;
                case "Russia": return _russia;
                case "UAE": return _UAE;
                case "Korea": return _korea;
                case "Netherlands": return _netherlands;
                default:
                    return _unknown;
            }
        }

        public static string FlagByCountryAndroid(string country)
        {
            switch (country)
            {
                case "Spain": return a_spain;
                case "Australia": return a_australia;
                case "Morocco": return a_morocco;
                case "UK": return a_UK;
                case "USA": return a_USA;
                case "Sweden": return a_sweden;
                case "Germany": return a_germany;
                case "Bahrain": return a_bahrain;
                case "Azerbaijan": return a_azerbaijan;
                case "Portugal": return a_portugal;
                case "Switzerland": return a_switzerland;
                case "India": return a_india;
                case "France": return a_france;
                case "Japan": return a_japan;
                case "Argentina": return a_argentina;
                case "South Africa": return a_southafrica;
                case "Vietnam": return a_vietnam;
                case "Hungary": return a_hungary;
                case "Italy": return a_italy;
                case "Brazil": return a_brazil;
                case "Turkey": return a_turkey;
                case "Singapore": return a_singapore;
                case "Monaco": return a_monaco;
                case "Canada": return a_canada;
                case "Belgium": return a_belgium;
                case "Austria": return a_austria;
                case "Mexico": return a_mexico;
                case "Malaysia": return a_malaysia;
                case "China": return a_china;
                case "Russia": return a_russia;
                case "UAE": return a_UAE;
                case "Korea": return a_korea;
                case "Netherlands": return a_netherlands;
                default:
                    return a_unknown;
            }
        }

        /// <summary>
        /// Gets the flag depends on the nationality.
        /// </summary>
        /// <param name="nationality">Nationality string</param>
        /// <returns>Wikipedia URL flag.</returns>
        public static string FlagByNationality(string nationality)
        {

            if (Device.RuntimePlatform == Device.Android)
                return FlagByNationalityAndroid(nationality);

            switch (nationality)
            {
                case "Spanish":
                    return _spain;
                case "British":
                    return _UK;
                case "Italian":
                    return _italy;
                case "American":
                    return _USA;
                case "Belgian":
                    return _belgium;
                case "German":
                    return _germany;
                case "Dutch":
                    return _netherlands;
                case "Thai":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a9/Flag_of_Thailand.svg/1280px-Flag_of_Thailand.svg.png";
                case "French":
                    return _france;
                case "New Zealander":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3e/Flag_of_New_Zealand.svg/1920px-Flag_of_New_Zealand.svg.png";
                case "Swedish":
                    return _sweden;
                case "Brazilian":
                    return _brazil;
                case "Hungarian":
                    return _hungary;
                case "Danish":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9c/Flag_of_Denmark.svg/1024px-Flag_of_Denmark.svg.png";
                case "Monegasque":
                    return _monaco;
                case "Finnish":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bc/Flag_of_Finland.svg/1280px-Flag_of_Finland.svg.png";
                case "Australian":
                    return _australia;
                case "Russian":
                    return _russia;
                case "Mexican":
                    return _mexico;
                case "Canadian":
                    return _canada;
                case "Polish":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/Flag_of_Poland.svg/1280px-Flag_of_Poland.svg.png";
                case "Austrian":
                    return _austria;
                case "Argentine":
                    return _argentina;
                case "South African":
                    return _southafrica;
                case "Swiss":
                    return _switzerland;
                case "Portuguese":
                    return _portugal;
                case "Uruguayan":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Flag_of_Uruguay.svg/1280px-Flag_of_Uruguay.svg.png";
                case "Venezuelan":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Flag_of_Venezuela_%28state%29.svg/1280px-Flag_of_Venezuela_%28state%29.svg.png";
                case "Indian":
                    return _india;
                case "Irish":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/4/45/Flag_of_Ireland.svg/1920px-Flag_of_Ireland.svg.png";
                case "Czech":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Flag_of_the_Czech_Republic.svg/1280px-Flag_of_the_Czech_Republic.svg.png";
                case "East German":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/9/97/Flag_of_the_German_Democratic_Republic.svg/1280px-Flag_of_the_German_Democratic_Republic.svg.png";
                case "Japanese":
                    return _japan;
                case "Colombian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/2/21/Flag_of_Colombia.svg/1280px-Flag_of_Colombia.svg.png";
                case "Indonesian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/Flag_of_Indonesia.svg/1280px-Flag_of_Indonesia.svg.png";
                case "Rhodesian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/0/02/Flag_of_Rhodesia_%281968%E2%80%931979%29.svg/1920px-Flag_of_Rhodesia_%281968%E2%80%931979%29.svg.png";
                case "Liechtensteiner":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/4/47/Flag_of_Liechtenstein.svg/1280px-Flag_of_Liechtenstein.svg.png";
                case "Malaysian":
                    return _malaysia;
                case "Hong Kong":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5b/Flag_of_Hong_Kong.svg/1280px-Flag_of_Hong_Kong.svg.png";
                case "American-Italian":
                case "Argentine-Italian":
                default:
                    return _unknown;
            }
        }

        public static string FlagByNationalityAndroid(string nationality)
        {
            switch (nationality)
            {
                case "Spanish":
                    return a_spain;
                case "British":
                    return a_UK;
                case "Italian":
                    return a_italy;
                case "American":
                    return a_USA;
                case "Belgian":
                    return a_belgium;
                case "German":
                    return a_germany;
                case "Dutch":
                    return a_netherlands;
                case "Thai":
                    return "thai.png";
                case "French":
                    return a_france;
                case "New Zealander":
                    return "newzeland.png";
                case "Swedish":
                    return a_sweden;
                case "Brazilian":
                    return a_brazil;
                case "Hungarian":
                    return a_hungary;
                case "Danish":
                    return "denmark.png";
                case "Monegasque":
                    return a_monaco;
                case "Finnish":
                    return "finland.png";
                case "Australian":
                    return a_australia;
                case "Russian":
                    return a_russia;
                case "Mexican":
                    return a_mexico;
                case "Canadian":
                    return a_canada;
                case "Polish":
                    return "poland.png";
                case "Austrian":
                    return a_austria;
                case "Argentine":
                    return a_argentina;
                case "South African":
                    return a_southafrica;
                case "Swiss":
                    return a_switzerland;
                case "Portuguese":
                    return a_portugal;
                case "Uruguayan":
                    return "uruguay.png";
                case "Venezuelan":
                    return "venezuela.png";
                case "Indian":
                    return a_india;
                case "Irish":
                    return "irland.png";
                case "Czech":
                    return "czech.png";
                case "Japanese":
                    return a_japan;
                case "Colombian":
                    return "colombia.png";
                case "Indonesian":
                    return "indonesia.png";
                case "Liechtensteiner":
                    return "liechtenstein.png";
                case "Malaysian":
                    return a_malaysia;
                case "Hong Kong":
                    return "hongkong.png";
                case "American-Italian":
                case "Argentine-Italian":
                case "East German":
                case "Rhodesian":
                default:
                    return a_unknown;
            }
        }
    }
}
