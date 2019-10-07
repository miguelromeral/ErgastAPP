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

        string _driverId;
        DataErgastDrivers _drivers;


        public DriverDetailViewModel(string driverId)
        {
            _driverId = driverId;
            
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                _drivers = await App.RestService.GetDriverInfoAsync(_driverId);
                Item = _drivers.DriverTable.Drivers[0];
                Title = Item.Fullname;
                var s = await App.RestService.GetSeasonsDriverWorldChampionAsync(_driverId);
                if (s != null)
                    SeasonsWorldChampions = s.SeasonTable;
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
