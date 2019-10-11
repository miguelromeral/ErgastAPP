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

        public RaceTable Data { get; set; }


        enum DataSource
        {
            All,
            Seasons,
            RacesProvided
        }

        DataSource _source;

        public RaceViewModel()
        {
            Title = "Races";
            Items = new ObservableCollection<Race>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _source = DataSource.All;
        }

        public RaceViewModel(Season s)
        {
            Season = s;
            Title = s.Year + " Races";
            Items = new ObservableCollection<Race>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _source = DataSource.Seasons;
        }

        public RaceViewModel(RaceTable races, string title = "Races")
        {
            Title = title;
            Data = races;
            Items = new ObservableCollection<Race>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _source = DataSource.RacesProvided;
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
                    case DataSource.Seasons:
                        Data = await App.RestService.GetRacesBySeasonAsync(Season.Year);
                        break;
                    case DataSource.RacesProvided:
                        // If it's already provided, there's no need to request the data.
                        break;
                    case DataSource.All:
                    default:
                        Data = await App.RestService.GetRacesAsync();
                        break;
                }
                
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
