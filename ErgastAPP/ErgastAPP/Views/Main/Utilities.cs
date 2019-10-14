using ErgastAPP.Models;
using ErgastAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ErgastAPP.Views
{
    public static class Utilities
    {

        static string warning_title = "Data not available yet";
        static string warning_body = "Please, wait until the data is successfully loaded";
        static string warning_answer = "OK";

        

        public static void OpenSeasons(ContentPage page, SeasonOrigin origin, SeasonTable seasons, Driver driver)
        {
            if (seasons != null && driver != null)
            {
                string title = "Seasons";

                switch (origin)
                {
                    case SeasonOrigin.DriverSeasons:
                        title = driver.Fullname + " Seasons";
                        break;
                    case SeasonOrigin.DriverWorldChampion:
                        title = driver.Fullname + " World Champions";
                        break;
                    default:
                        break;
                }

                page.Navigation.PushAsync(new SeasonsPage(new SeasonViewModel(seasons, title)));
            }
            else
                page.DisplayAlert(warning_title, warning_body, warning_answer);
        }
    }
}
