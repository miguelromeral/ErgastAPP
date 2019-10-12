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
        public Command LoadLaps { get; set; }
        public Command LoadStops { get; set; }
        
        public Command MainCommand { get; set; }


        private Result _result;
        public Result Result { get { return _result; } set { SetProperty(ref _result, value); } }

        private Race _race;
        public Race Race { get { return _race; } set { SetProperty(ref _race, value); } }


        private Driver _driver;
        public Driver Driver { get { return _driver; } set { SetProperty(ref _driver, value); } }


        public ObservableCollection<Lap> Laps { get; set; }
        public ObservableCollection<PitStop> PitStops { get; set; }


        public ResultDetailViewModel(Result r, Race ra, Driver d, string title)
        {
            Result = r;
            Race = ra;
            Driver = d;
            Title = title;
            Laps = new ObservableCollection<Lap>();
            PitStops = new ObservableCollection<PitStop>();
            LoadLaps = new Command(async () => await ExecuteLoadLapsCommand());
            LoadStops = new Command(async () => await ExecuteLoadStopsCommand());
            MainCommand = new Command(async () => await ExecuteMainCommand());
        }

        async Task ExecuteMainCommand()
        {
            await ExecuteLoadStopsCommand();
            await ExecuteLoadLapsCommand();
        }

        async Task ExecuteLoadLapsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var laps = await App.RestService.LapsByRaceAndDriverAsync(Race.Season, Race.Round, Driver.Id);
                Race.Laps = laps.Laps;
                Laps.Clear();
                foreach (var l in laps.Laps)
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

        async Task ExecuteLoadStopsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var stops = await App.RestService.PitStopsByRaceAndDriverAsync(Race.Season, Race.Round, Driver.Id);
                Race.PitStops = stops.PitStops;
                PitStops.Clear();
                foreach (var p in stops.PitStops)
                {
                    PitStops.Add(p);
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
