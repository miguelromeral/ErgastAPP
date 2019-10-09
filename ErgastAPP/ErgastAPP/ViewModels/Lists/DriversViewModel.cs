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
   
        public ObservableCollection<string> Years { get; set; }
        public ObservableCollection<string> Rounds { get; set; }

        public int? YearPicked { get; set; }
        public int? RoundPicked { get; set; }

        string racename;
        public string Racename { get { return racename; } set { SetProperty(ref racename, value); } }

        RaceTable _races;
        DataErgastDrivers _drivers;

        public static string ALL_TEXT = "All";

        public DriversViewModel(int? year = null, int? round = null)
        {
            Title = "Drivers";
            YearPicked = year;
            RoundPicked = round;
            Items = new ObservableCollection<Driver>();
            Years = new ObservableCollection<string>();
            Rounds = new ObservableCollection<string>();
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
                    Years.Add(ALL_TEXT);
                    var seasons = await App.RestService.GetSeasonsDataAsync();
                    foreach (var s in seasons.SeasonTable.Seasons)
                    {
                        Years.Add(s.Year.ToString());
                    }
                }

                if(Rounds.Count == 0)
                {
                    Rounds.Clear();
                    Rounds.Add(ALL_TEXT);
                    if (YearPicked != null)
                    {
                        _races = await App.RestService.GetRacesBySeasonAsync((int)YearPicked);
                        foreach (var s in _races.Races)
                        {
                            Rounds.Add(s.Round.ToString());
                        }
                    }
                }
                
                _drivers = await App.RestService.GetDriversAsync(YearPicked, RoundPicked);
                _drivers.DriverTable.Drivers = _drivers.DriverTable.Drivers.OrderBy(o => o.Fullname).ToList();
                LoadItemsFromData();
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


        public void LoadItemsFromData(string content = "")
        {
            Items.Clear();
            foreach (var item in _drivers.DriverTable.Drivers.Where(i => i.Fullname.ToLower().Contains(content.ToLower())))
            {
                Items.Add(item);
            }
            SetGPInfo();
        }


        public void SetGPInfo()
        {
            if (_races != null)
            {
                foreach (var r in _races.Races)
                {
                    if (r.Round == RoundPicked)
                    {
                        Racename = r.Season + " " + r.Name;
                        return;
                    }
                }
            }
            if (YearPicked == null)
                Racename = "ALL DRIVERS";
            else 
                Racename = YearPicked + " Season";
        }
    }
}
