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
    public class RaceViewModel : BaseViewModel
    {
        public ObservableCollection<Race> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private int _year;

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
                Items.Clear();
                DataErgastRaces data = await App.RestService.GetRacesBySeasonAsync(App.API.RacesBySeason(_year)) as DataErgastRaces;
                Title = data.RaceTable.Season.ToString();
                foreach (var item in data.RaceTable.Races)
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
    }
}
