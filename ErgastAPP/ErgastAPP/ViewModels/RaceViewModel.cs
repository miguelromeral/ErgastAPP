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
        private int _year;

        public DataErgastRaces Data { get; set; }

        public RaceViewModel(int year)
        {
            Title = "Races";
            _year = year;
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
                Data = await App.RestService.GetRacesBySeasonAsync(_year);
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

            var aux = Data.RaceTable.Races.Where(i => i.Name.ToLower().Contains(content.ToLower()));

            foreach (var item in aux)
            {
                Items.Add(item);
            }
        }
    }
}
