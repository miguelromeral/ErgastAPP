using ErgastAPP.Models;
using ErgastAPP.ViewModels;
using ErgastAPP.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ErgastAPP.Services
{
    public static class Navigator
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
                        title = driver.FamilyName + " Seasons";
                        break;
                    case SeasonOrigin.DriverWorldChampion:
                        title = driver.FamilyName + " World Champions";
                        break;
                    default:
                        break;
                }

                page.Navigation.PushAsync(new SeasonsPage(new SeasonViewModel(seasons, title)));
            }
            else
                page.DisplayAlert(warning_title, warning_body, warning_answer);
        }



        public static void OpenRaces(ContentPage page, RaceOrigin origin, RaceTable races, Driver driver)
        {
            if (races != null && driver != null)
            {
                string title = "Seasons";
                var racetable = new RaceTable();

                switch (origin)
                {
                
                    case RaceOrigin.DriverPodiums:
                        title = driver.FamilyName + " Podiums";
                        racetable.Races = races.RacesPodiums;
                        break;
                    case RaceOrigin.DriverWins:
                        title = driver.FamilyName + " Wins";
                        racetable.Races = races.RacesWon;
                        break;
                    case RaceOrigin.DriverPoles:
                        title = driver.FamilyName + " Pole Positios";
                        racetable.Races = races.RacesPolePosition;
                        break;
                    case RaceOrigin.DriverRaces:
                        title = driver.FamilyName + " Races";
                        racetable = races;
                        break;
                    default:
                        break;
                }

                page.Navigation.PushAsync(new RacePage(new RaceViewModel(racetable, title)));
            }
            else
                page.DisplayAlert(warning_title, warning_body, warning_answer);
        }

        public static void OpenRaces(ContentPage page, Season season)
        {
            if(season != null) { 
                page.Navigation.PushAsync(new RacePage(new RaceViewModel(season)));
            }
            else
                page.DisplayAlert(warning_title, warning_body, warning_answer);
        }



        public static void OpenRaceDetail(ContentPage page, int year, int round)
        {
            page.Navigation.PushAsync(new RaceDetailPage(new RaceDetailViewModel(year, round)));
        }

        public static void OpenRaceDetail(ContentPage page, Race race)
        {
            if (race != null)
            {
                page.Navigation.PushAsync(new RaceDetailPage(new RaceDetailViewModel(race)));
            }
            //else
            //    page.DisplayAlert(warning_title, warning_body, warning_answer);
        }

        public async static void OpenRaceDetailLast(ContentPage page)
        {
            await page.Navigation.PushAsync(new RaceDetailPage(new RaceDetailViewModel(await App.RestService.GetLastRaceAsync())));
        }

        

        public static void OpenDriverDetail(ContentPage page, string driver)
        {
            page.Navigation.PushAsync(new DriverDetailPage(new DriverDetailViewModel(driver)));
        }


        public static void OpenDriverDetail(ContentPage page, Driver driver)
        {
            if(driver != null)
                page.Navigation.PushAsync(new DriverDetailPage(new DriverDetailViewModel(driver)));
            else
                page.DisplayAlert(warning_title, warning_body, warning_answer);
        }



        public static void OpenCircuitDetail(ContentPage page, Circuit circuit)
        {
            if (circuit != null)
                page.Navigation.PushAsync(new CircuitDetailPage(new CircuitDetailViewModel(circuit)));
            else
                page.DisplayAlert(warning_title, warning_body, warning_answer);
        }




        public static void OpenResultDetail(ContentPage page, Result result, Race race, Driver driver)
        {
            if (result != null && race != null && driver != null)
            {
                page.Navigation.PushAsync(new ResultDetailPage(new ResultDetailViewModel(result, race, driver, driver.FamilyName+ " in " + race.Season + " " + race.Name)));
            }
            else
                page.DisplayAlert(warning_title, warning_body, warning_answer);
        }
    }
}
