using System;
using System.Collections.Generic;
using System.Text;

namespace ErgastAPP.Resources
{
    public static class Images
    {

        public static string FlagByNationality(string nat)
        {
            switch (nat)
            {
                case "Spanish":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/Flag_of_Spain.svg/1280px-Flag_of_Spain.svg.png";
                case "British":
                    return "https://upload.wikimedia.org/wikipedia/en/thumb/a/ae/Flag_of_the_United_Kingdom.svg/1920px-Flag_of_the_United_Kingdom.svg.png";
                case "Italian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/0/03/Flag_of_Italy.svg/1280px-Flag_of_Italy.svg.png";
                case "American":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/Flag_of_the_United_States.svg/1920px-Flag_of_the_United_States.svg.png";
                case "Belgian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/Flag_of_Belgium.svg/1024px-Flag_of_Belgium.svg.png";
                case "German":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/b/ba/Flag_of_Germany.svg/1280px-Flag_of_Germany.svg.png";
                case "Dutch":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Flag_of_the_Netherlands.svg/1280px-Flag_of_the_Netherlands.svg.png";
                case "Thai":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a9/Flag_of_Thailand.svg/1280px-Flag_of_Thailand.svg.png";
                case "French":
                    return "https://upload.wikimedia.org/wikipedia/en/thumb/c/c3/Flag_of_France.svg/1280px-Flag_of_France.svg.png";
                case "New Zealander":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3e/Flag_of_New_Zealand.svg/1920px-Flag_of_New_Zealand.svg.png";
                case "Swedish":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4c/Flag_of_Sweden.svg/1280px-Flag_of_Sweden.svg.png";
                case "Brazilian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/0/05/Flag_of_Brazil.svg/1280px-Flag_of_Brazil.svg.png";
                case "Hungarian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Flag_of_Hungary.svg/1920px-Flag_of_Hungary.svg.png";
                case "Danish":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9c/Flag_of_Denmark.svg/1024px-Flag_of_Denmark.svg.png";
                case "Monegasque":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Flag_of_Monaco.svg/1024px-Flag_of_Monaco.svg.png";
                case "Finnish":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bc/Flag_of_Finland.svg/1280px-Flag_of_Finland.svg.png";
                case "Australian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/Flag_of_Australia_%28converted%29.svg/1920px-Flag_of_Australia_%28converted%29.svg.png";
                case "Russian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f3/Flag_of_Russia.svg/1280px-Flag_of_Russia.svg.png";
                case "Mexican":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Flag_of_Mexico.svg/1920px-Flag_of_Mexico.svg.png";
                case "Canadian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Flag_of_Canada_%28Pantone%29.svg/1920px-Flag_of_Canada_%28Pantone%29.svg.png";
                case "Polish":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/Flag_of_Poland.svg/1280px-Flag_of_Poland.svg.png";
                case "Austrian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/4/41/Flag_of_Austria.svg/1280px-Flag_of_Austria.svg.png";
                case "Argentine":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1a/Flag_of_Argentina.svg/1280px-Flag_of_Argentina.svg.png";
                case "South African":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/a/af/Flag_of_South_Africa.svg/1280px-Flag_of_South_Africa.svg.png";
                case "Swiss":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/0/08/Flag_of_Switzerland_%28Pantone%29.svg/800px-Flag_of_Switzerland_%28Pantone%29.svg.png";
                case "Portuguese":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5c/Flag_of_Portugal.svg/1280px-Flag_of_Portugal.svg.png";
                case "Uruguayan":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Flag_of_Uruguay.svg/1280px-Flag_of_Uruguay.svg.png";
                case "Venezuelan":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Flag_of_Venezuela_%28state%29.svg/1280px-Flag_of_Venezuela_%28state%29.svg.png";
                case "Indian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/4/41/Flag_of_India.svg/1280px-Flag_of_India.svg.png";
                case "Irish":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/4/45/Flag_of_Ireland.svg/1920px-Flag_of_Ireland.svg.png";
                case "Argentine-Italian":
                    return "";
                case "Czech":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Flag_of_the_Czech_Republic.svg/1280px-Flag_of_the_Czech_Republic.svg.png";
                case "East German":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/9/97/Flag_of_the_German_Democratic_Republic.svg/1280px-Flag_of_the_German_Democratic_Republic.svg.png";
                case "Japanese":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Flag_of_Japan.svg/1280px-Flag_of_Japan.svg.png";
                case "Colombian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/2/21/Flag_of_Colombia.svg/1280px-Flag_of_Colombia.svg.png";
                case "Indonesian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/Flag_of_Indonesia.svg/1280px-Flag_of_Indonesia.svg.png";
                case "Rhodesian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/0/02/Flag_of_Rhodesia_%281968%E2%80%931979%29.svg/1920px-Flag_of_Rhodesia_%281968%E2%80%931979%29.svg.png";
                case "American-Italian":
                    return "";
                case "Liechtensteiner":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/4/47/Flag_of_Liechtenstein.svg/1280px-Flag_of_Liechtenstein.svg.png";
                case "Malaysian":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/6/66/Flag_of_Malaysia.svg/1920px-Flag_of_Malaysia.svg.png";
                case "Hong Kong":
                    return "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5b/Flag_of_Hong_Kong.svg/1280px-Flag_of_Hong_Kong.svg.png";
                default:
                    return "";
            }
        }
    }
}
