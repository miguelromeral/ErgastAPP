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
    /// <summary>
    /// ViewModel for Result details page.
    /// </summary>
    /// <seealso cref="ErgastAPP.ViewModels.BaseViewModel" />
    public class ResultDetailViewModel : BaseViewModel
    {
        /// <summary>
        /// Command to load all the laps.
        /// </summary>
        public Command LoadLaps { get; set; }
        /// <summary>
        /// Command to load the pit stops.
        /// </summary>
        public Command LoadStops { get; set; }

        /// <summary>
        /// Command to load all the data at the begining.
        /// </summary>
        /// <value>
        /// The main command.
        /// </value>
        public Command MainCommand { get; set; }

        /// <summary>
        /// The result
        /// </summary>
        private Result _result;
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Result Result { get { return _result; } set { SetProperty(ref _result, value); } }

        /// <summary>
        /// The race that result belongs to.
        /// </summary>
        private Race _race;
        /// <summary>
        /// Gets or sets the race.
        /// </summary>
        /// <value>
        /// The race.
        /// </value>
        public Race Race { get { return _race; } set { SetProperty(ref _race, value); } }

        /// <summary>
        /// The driver who got that result.
        /// </summary>
        private Driver _driver;
        /// <summary>
        /// Gets or sets the driver.
        /// </summary>
        /// <value>
        /// The driver.
        /// </value>
        public Driver Driver { get { return _driver; } set { SetProperty(ref _driver, value); } }

        /// <summary>
        /// List of laps displayed on the layout.
        /// </summary>
        /// <value>
        /// The laps.
        /// </value>
        public ObservableCollection<Lap> Laps { get; set; }
        /// <summary>
        /// List of pit stops displayed on the layout.
        /// </summary>
        /// <value>
        /// The pit stops.
        /// </value>
        public ObservableCollection<PitStop> PitStops { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultDetailViewModel"/> class.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="ra">The ra.</param>
        /// <param name="d">The d.</param>
        /// <param name="title">The title.</param>
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

        /// <summary>
        /// Executes the main command in order to get the laps and pit stops times at the same time.
        /// </summary>
        async Task ExecuteMainCommand()
        {
            await ExecuteLoadStopsCommand();
            await ExecuteLoadLapsCommand();
        }

        /// <summary>
        /// Executes the load laps command.
        /// </summary>
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

        /// <summary>
        /// Executes the load stops command.
        /// </summary>
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
