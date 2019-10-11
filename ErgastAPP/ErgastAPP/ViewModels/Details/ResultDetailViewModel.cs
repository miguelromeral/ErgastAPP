using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ErgastAPP.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace ErgastAPP.ViewModels
{
    public class ResultDetailViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        private Result _result;
        public Result Result { get { return _result; } set { SetProperty(ref _result, value); } }

        private Race _race;
        public Race Race { get { return _race; } set { SetProperty(ref _race, value); } }


        private Driver _driver;
        public Driver Driver { get { return _driver; } set { SetProperty(ref _driver, value); } }


        public ObservableCollection<Lap> Laps { get; set; }


        public ResultDetailViewModel(Result r, Race ra, Driver d, string title)
        {
            Result = r;
            Race = ra;
            Driver = d;
            Title = title;
            Laps = new ObservableCollection<Lap>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var laps = await App.RestService.LapsByRaceAndDriverAsync(Race.Season, Race.Round, Driver.Id);
                Laps.Clear();
                foreach(var l in laps.Laps)
                {
                    Laps.Add(l);
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
