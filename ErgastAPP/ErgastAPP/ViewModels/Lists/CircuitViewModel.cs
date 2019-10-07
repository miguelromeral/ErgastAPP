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
    class CircuitViewModel : BaseViewModel
    {
        public ObservableCollection<Circuit> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ObservableCollection<string> Years { get; set; }

        public int? YearPicked { get; set; }
        
        DataErgastRaces _races;
        DataErgastCircuits _circuits;

        public static string ALL_TEXT = "All";

        public CircuitViewModel(int? year = null)
        {
            Title = "Circuits";
            YearPicked = year;
            Items = new ObservableCollection<Circuit>();
            Years = new ObservableCollection<string>();
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
                
                _circuits = await App.RestService.GetCircuitsAsync(YearPicked);
                _circuits.CircuitTable.Circuits = _circuits.CircuitTable.Circuits.OrderBy(o => o.Name).ToList();
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
            foreach (var item in _circuits.CircuitTable.Circuits.Where(i => i.Name.ToLower().Contains(content.ToLower())))
            {
                Items.Add(item);
            }
        }
    }
}
