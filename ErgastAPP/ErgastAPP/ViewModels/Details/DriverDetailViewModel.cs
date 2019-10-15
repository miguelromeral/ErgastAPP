using ErgastAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ErgastAPP.ViewModels
{
    public class DriverDetailViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }
        
        Driver driver;
        public Driver Item { get { return driver; } set { SetProperty(ref driver, value); } }

        Driver original;

        SeasonTable seasonsWorldChampion;
        public SeasonTable SeasonsWorldChampions { get { return seasonsWorldChampion; } set { SetProperty(ref seasonsWorldChampion, value); } }

        RaceTable races;
        public RaceTable Races { get { return races; } set { SetProperty(ref races, value); } }

        ConstructorTable constructors;
        public ConstructorTable Constructors { get { return constructors; } set { SetProperty(ref constructors, value); } }


        SeasonTable seasons;
        public SeasonTable Seasons { get { return seasons; } set { SetProperty(ref seasons, value); } }



        public string DriverId;
        DriverTable _drivers;

        RaceTable fastestLaps;
        public RaceTable FastestLaps { get { return fastestLaps; } set { SetProperty(ref fastestLaps, value); } }


        enum DataSource
        {
            Id,
            Driver
        }
        DataSource _source;
        

        public DriverDetailViewModel(string driverId)
        {
            DriverId = driverId;
            _source = DataSource.Id;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        public DriverDetailViewModel(Driver d)
        {
            DriverId = d.Id;
            original = d;
            _source = DataSource.Driver;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        private async void LoadDriverFromId()
        {
            _drivers = await App.RestService.GetDriverInfoAsync(DriverId);
            original = _drivers.Drivers[0];
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                switch (_source)
                {
                    case DataSource.Driver:
                        break;
                    case DataSource.Id:
                    default:
                        LoadDriverFromId();
                        break;
                }

                Races = await App.RestService.RacesByDriverAsync(DriverId);
                Constructors = await App.RestService.ConstructorsByDriverAsync(DriverId);
                FastestLaps = await App.RestService.FastestLapsByDriverAsync(DriverId);
                SeasonsWorldChampions = await App.RestService.GetSeasonsDriverWorldChampionAsync(DriverId);
                Seasons = await App.RestService.GetSeasonsByDriverAsync(DriverId);
                Item = original;
                Title = Item.Fullname;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
