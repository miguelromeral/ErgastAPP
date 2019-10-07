using ErgastAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ErgastAPP.ViewModels
{
    public class RaceViewModel : BaseViewModel
    {
        public ObservableCollection<Race> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public Season Season;

        public DataErgastRaces Data { get; set; }

        public RaceViewModel(Season s)
        {
            Season = s;
            Title = s.Year+" Races";
            Items = new ObservableCollection<Race>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Data = await App.RestService.GetRacesBySeasonAsync(Season.Year);
                Title = Data.RaceTable.Season.ToString();
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
            foreach (var item in Data.RaceTable.Races.Where(i => i.Name.ToLower().Contains(content.ToLower())))
            {
                Items.Add(item);
            }
        }
    }
}
