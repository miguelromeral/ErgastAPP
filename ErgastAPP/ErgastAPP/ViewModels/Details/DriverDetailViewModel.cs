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

        SeasonTable seasonsWorldChampion;
        public SeasonTable SeasonsWorldChampions { get { return seasonsWorldChampion; } set { SetProperty(ref seasonsWorldChampion, value); } }

        RaceTable races;
        public RaceTable Races { get { return races; } set { SetProperty(ref races, value); } }

      

        public string DriverId;
        DataErgastDrivers _drivers;


        public DriverDetailViewModel(string driverId)
        {
            DriverId = driverId;
            
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                _drivers = await App.RestService.GetDriverInfoAsync(DriverId);
                Item = _drivers.DriverTable.Drivers[0];
                Title = Item.Fullname;
                var s = await App.RestService.GetSeasonsDriverWorldChampionAsync(DriverId);
                if (s != null)
                    SeasonsWorldChampions = s.SeasonTable;

                Races = await App.RestService.RacesByDriverAsync(DriverId);
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
