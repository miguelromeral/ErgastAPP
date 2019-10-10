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
        public Driver Driver;

        public RaceTable Data { get; set; }

        public RaceViewModel(Season s)
        {
            Season = s;
            Title = s.Year + " Races";
            Items = new ObservableCollection<Race>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommandSeason());
        }
        
        public RaceViewModel(Driver d, RaceTable races, string title = "Races")
        {
            Driver = d;
            Title = title;
            Data = races;
            Items = new ObservableCollection<Race>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommandDriver());
        }


        async Task ExecuteLoadItemsCommandSeason()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Data = await App.RestService.GetRacesBySeasonAsync(Season.Year);
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


        async Task ExecuteLoadItemsCommandDriver()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
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
            int count = 1;
            foreach (var item in Data.Races.Where(i => i.Name.ToLower().Contains(content.ToLower()) ||
            i.Circuit.Name.ToLower().Contains(content.ToLower()) || i.Date.ToLower().Contains(content.ToLower())))
            {
                item.Number = count;
                Items.Add(item);
                count++;
            }
        }
    }
}
