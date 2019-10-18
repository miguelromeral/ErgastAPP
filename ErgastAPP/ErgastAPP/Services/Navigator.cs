using ErgastAPP.Models;
using ErgastAPP.ViewModels;
using ErgastAPP.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ErgastAPP.Services
{
    /// <summary>
    /// Push instances of Activities in function of the page the user wants to be displayed.
    /// </summary>
    public static class Navigator
    {
        // Warning titles.
        static readonly string warning_title = "Data not available yet";
        static readonly string warning_body = "Please, wait until the data is successfully loaded";
        static readonly string warning_answer = "OK";



        public static void OpenSeasons(ContentPage page, SeasonTable seasons, string title, bool warning = true)
        {
            if (seasons != null)
            {
                page.Navigation.PushAsync(new SeasonsPage(new SeasonViewModel(seasons, title)));
            }
            else
                ShowWarning(page, warning);
        }

        public static void OpenSeasons(ContentPage page, SeasonOrigin origin, SeasonTable seasons, Constructor constructor, bool warning = true)
        {
            if (seasons != null && constructor != null)
            {
                string title = "Seasons";

                switch (origin)
                {
                    case SeasonOrigin.ConstructorWorldChampion:
                        title = constructor.Name + " World Champions";
                        break;
                    default:
                        break;
                }

                page.Navigation.PushAsync(new SeasonsPage(new SeasonViewModel(seasons, title)));
            }
            else
                ShowWarning(page, warning);
        }



        public static void OpenRaces(ContentPage page, RaceOrigin origin, RaceTable races, Driver driver, bool warning = true)
        {
            if (races != null && driver != null)
            {
                string title = "Races";
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
                    case RaceOrigin.DriverFastestLaps:
                        title = driver.FamilyName + " Fastest Laps";
                        racetable = races;
                        break;
                    default:
                        break;
                }

                page.Navigation.PushAsync(new RacePage(new RaceViewModel(racetable, title)));
            }
            else
                ShowWarning(page, warning);
        }


        public static void OpenRaces(ContentPage page, RaceOrigin origin, RaceTable races, Constructor constructor, bool warning = true)
        {
            if (races != null && constructor != null)
            {
                string title = "Races";
                var racetable = new RaceTable();

                switch (origin)
                {
                    case RaceOrigin.ConstructorFastestLaps:
                        title = constructor.Name + " Fastest Laps";
                        racetable = races;
                        break;
                    case RaceOrigin.ConstructorPodiums:
                        title = constructor.Name + " Podiums";
                        racetable.Races = races.RacesPodiums;
                        break;
                    case RaceOrigin.ConstructorWins:
                        title = constructor.Name + " Wins";
                        racetable.Races = races.RacesWon;
                        break;
                    case RaceOrigin.ConstructorPoles:
                        title = constructor.Name + " Pole Positions";
                        racetable.Races = races.RacesPolePosition;
                        break;
                    case RaceOrigin.ConstructorRaces:
                        title = constructor.Name + " Races";
                        racetable.Races = races.Races;
                        break;
                    default:
                        break;
                }

                page.Navigation.PushAsync(new RacePage(new RaceViewModel(racetable, title)));
            }
            else
                ShowWarning(page, warning);
        }
        public static void OpenRaces(ContentPage page, RaceOrigin origin, RaceTable races, Circuit circuit, bool warning = true)
        {
            if (races != null && circuit != null)
            {
                string title = "Races";

                switch (origin)
                {
                    case RaceOrigin.CircuitRaces:
                        title = circuit.Name + " Races";
                        break;
                    default:
                        break;
                }

                page.Navigation.PushAsync(new RacePage(new RaceViewModel(races, title)));
            }
            else
                ShowWarning(page, warning);
        }

        public static void OpenRaces(ContentPage page, Season season, bool warning = true)
        {
            if (season != null)
            {
                page.Navigation.PushAsync(new RacePage(new RaceViewModel(season)));
            }
            else
                ShowWarning(page, warning);
        }

        public static void OpenConstructor(ContentPage page, ConstructorOrigin origin, ConstructorTable constructors, Driver driver, bool warning = true)
        {
            if (driver != null && constructors != null)
            {
                string title = "Constructors";

                switch (origin)
                {
                    case ConstructorOrigin.Drivers:
                        title = driver.FamilyName + " Constructors";
                        break;
                    default:
                        break;
                }
                page.Navigation.PushAsync(new ConstructorPage(new ConstructorViewModel(constructors, title)));
            }
            else
                ShowWarning(page, warning);
        }

        

        public static void OpenRaceDetail(ContentPage page, int year, int round)
        {
            page.Navigation.PushAsync(new RaceDetailPage(new RaceDetailViewModel(year, round)));
        }

        public static void OpenRaceDetail(ContentPage page, Race race, bool warning = true)
        {
            if (race != null)
            {
                page.Navigation.PushAsync(new RaceDetailPage(new RaceDetailViewModel(race)));
            }
            else
                ShowWarning(page, warning);
        }
        
        

        public static void OpenConstructorDetail(ContentPage page, string constructor)
        {
            page.Navigation.PushAsync(new ConstructorDetailPage(new ConstructorDetailViewModel(constructor)));
        }

        public static void OpenConstructorDetail(ContentPage page, Constructor constructor, bool warning = true)
        {
            if (constructor != null)
                page.Navigation.PushAsync(new ConstructorDetailPage(new ConstructorDetailViewModel(constructor)));
            else
                ShowWarning(page, warning);
        }



        public static void OpenConstructorStandings(ContentPage page, Race race, bool warning = true)
        {
            if(race != null)
                page.Navigation.PushAsync(new ConstructorStandingDetailPage(new ConstructorStandingDetailViewModel(race)));
            else
                ShowWarning(page, warning);
        }

        public static void OpenDriverStandings(ContentPage page, Race race, bool warning = true)
        {
            if (race != null)
                page.Navigation.PushAsync(new DriverStandingDetailPage(new DriverStandingDetailViewModel(race)));
            else
                ShowWarning(page, warning);
        }




        public static void OpenDriver(ContentPage page, DriverOrigin origin, DriverTable drivers, Constructor constructor, bool warning = true)
        {
            if (drivers != null && constructor != null)
            {
                string title = "Drivers";

                switch (origin)
                {
                    case DriverOrigin.Constructors:
                        title = constructor.Name + " Drivers";
                        break;
                    default:
                        break;
                }

                page.Navigation.PushAsync(new DriversPage(new DriversViewModel(drivers, title)));
            }
            else
                ShowWarning(page, warning);
        }


        public static void OpenDriverDetail(ContentPage page, string driver)
        {
            page.Navigation.PushAsync(new DriverDetailPage(new DriverDetailViewModel(driver)));
        }


        public static void OpenDriverDetail(ContentPage page, Driver driver, bool warning = true)
        {
            if(driver != null)
                page.Navigation.PushAsync(new DriverDetailPage(new DriverDetailViewModel(driver)));
            else
                ShowWarning(page, warning);
        }



        public static void OpenCircuitDetail(ContentPage page, Circuit circuit, bool warning = true)
        {
            if (circuit != null)
                page.Navigation.PushAsync(new CircuitDetailPage(new CircuitDetailViewModel(circuit)));
            else
                ShowWarning(page, warning);
        }




        public static void OpenResultDetail(ContentPage page, Result result, Race race, Driver driver, bool warning = true)
        {
            if (result != null && race != null && driver != null)
            {
                page.Navigation.PushAsync(new ResultDetailPage(new ResultDetailViewModel(result, race, driver, driver.FamilyName+ " in " + race.Season + " " + race.Name)));
            }
            else
                ShowWarning(page, warning);
        }

        public static void OpenResult(ContentPage page, Race race, bool warning = true)
        {
            if (race != null)
            {
                page.Navigation.PushAsync(new ResultsPage(new ResultViewModel(race)));
            }
            else
                ShowWarning(page, warning);
        }
        public static void OpenQualy(ContentPage page, Race race, bool warning = true)
        {
            if (race != null)
            {
                page.Navigation.PushAsync(new QualyPage(new QualyViewModel(race)));
            }
            else
                ShowWarning(page, warning);
        }


        public static void OpenEvolution(ContentPage page, Race race, bool warning = true)
        {
            if (race != null)
                page.Navigation.PushAsync(new EvolutionPage(new EvolutionViewModel(race)));
            else
                ShowWarning(page, warning);
        }


        public static void ShowWarning(ContentPage page, bool warning)
        {
            if (warning)
            {
                page.DisplayAlert(warning_title, warning_body, warning_answer);
            }
        }
    }
}
