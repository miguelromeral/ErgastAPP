using ErgastAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ErgastAPP.ViewModels
{
    public class DriversViewModel : BaseViewModel
    {
        public ObservableCollection<Driver> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
   
        public ObservableCollection<int> Years { get; set; }
        public ObservableCollection<int> Rounds { get; set; }

        public int? YearPicked { get; set; }
        public int? RoundPicked { get; set; }

        public string Racename { get; set; }

        DataErgastRaces _races;

        public DriversViewModel(int? year = null, int? round = null)
        {
            Title = "Drivers";
            YearPicked = year;
            RoundPicked = round;
            Items = new ObservableCollection<Driver>();
            Years = new ObservableCollection<int>();
            Rounds = new ObservableCollection<int>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                if (Years.Count == 0)
                {
                    Years.Clear();
                    var seasons = await App.RestService.GetSeasonsDataAsync();
                    foreach (var s in seasons.SeasonTable.Seasons)
                    {
                        Years.Add(s.Year);
                    }
                }

                if(Rounds.Count == 0)
                {
                    Rounds.Clear();
                    _races = await App.RestService.GetRacesBySeasonAsync((int) YearPicked);
                    foreach (var s in _races.RaceTable.Races)
                    {
                        Rounds.Add(s.Round);
                    }
                }

                Items.Clear();
                var data = await App.RestService.GetDriversAsync(YearPicked, RoundPicked);
                data.DriverTable.Drivers = data.DriverTable.Drivers.OrderBy(o => o.Fullname).ToList();
                foreach (var item in data.DriverTable.Drivers)
                {
                    Items.Add(item);
                }
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

        public void SetGPInfo()
        {
            foreach(var r in _races.RaceTable.Races)
            {
                if(r.Round == RoundPicked)
                {
                    Racename = r.Season + " " + r.Name;
                    return;
                }
            }
        }
    }
}
