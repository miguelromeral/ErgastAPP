using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ErgastAPP.Models;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ErgastAPP.ViewModels
{
    /// <summary>
    /// ViewModel for Race Details.
    /// </summary>
    /// <seealso cref="ErgastAPP.ViewModels.BaseViewModel" />
    public class RaceDetailViewModel : BaseViewModel
    {
        /// <summary>
        /// Command to load all the data in the page.
        /// </summary>
        /// <value>
        /// The load items command.
        /// </value>
        public Command LoadItemsCommand { get; set; }

        /// <summary>
        /// The race
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
        /// The year of the race.
        /// </summary>
        public int _year;
        /// <summary>
        /// The round of the season.
        /// </summary>
        public int _round;

        /// <summary>
        /// The original race detail.
        /// </summary>
        private Race original;

        /// <summary>
        /// Gets or sets the layout qualy.
        /// </summary>
        /// <value>
        /// The layout qualy.
        /// </value>
        public StackLayout LayoutQualy { get; set; }
        /// <summary>
        /// Gets or sets the layout fastest lap.
        /// </summary>
        /// <value>
        /// The layout fastest lap.
        /// </value>
        public StackLayout LayoutFastestLap { get; set; }
        /// <summary>
        /// Gets or sets the button race evolution.
        /// </summary>
        /// <value>
        /// The button race evolution.
        /// </value>
        public Button ButtonRaceEvolution { get; set; }
        /// <summary>
        /// Gets or sets the button constructor standings.
        /// </summary>
        /// <value>
        /// The button constructor standings.
        /// </value>
        public Button ButtonConstructorStandings { get; set; }

        
        private const string _origin_yearround = "YearAndRound";

        /// <summary>
        /// Initializes a new instance of the <see cref="RaceDetailViewModel"/> class.
        /// </summary>
        /// <param name="year">The year of the race.</param>
        /// <param name="round">The round of the season.</param>
        public RaceDetailViewModel(int year, int round)
        {
            _year = year;
            _round = round;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(_origin_yearround));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaceDetailViewModel"/> class.
        /// </summary>
        /// <param name="race">The race to be detailed.</param>
        public RaceDetailViewModel(Race race)
        {
            _year = race.Season;
            _round = race.Round;
            original = race;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        /// <summary>
        /// Displays the layouts if the year is appropiate for the API.
        /// </summary>
        public void DisplayLayouts()
        {
            if(Race?.Season != null)
            {
                // Constructor Standings only available since 1958
                if (Race.Season >= 1958)
                {
                    ButtonConstructorStandings.IsVisible = true;
                    // Laps time only available since 1996
                    if (Race.Season >= 1996)
                    {
                        ButtonRaceEvolution.IsVisible = true;
                        // Layout times only available since 2003
                        if (Race.Season >= 2003)
                        {
                            LayoutQualy.IsVisible = true;
                            // Fastest lap times only available since 2004
                            if (Race.Season >= 2004)
                            {
                                LayoutFastestLap.IsVisible = true;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Executes the load items command.
        /// </summary>
        async Task ExecuteLoadItemsCommand(string origin = "")
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                // Set to null for later refresh the page.
                Race = null;

                // We only get the race info if is not provided.
                switch (origin)
                {
                    case _origin_yearround:
                        if (Race == null)
                        {
                            var data = await App.RestService.GetRaceResultsAsync(_year, _round);
                            original = data.Races[0];
                        }
                        break;
                    default:
                        break;
                }

                // Only gets results if not provided.
                if (original?.Results == null || original.Results.Count <= 5)
                {              
                    var res = await App.RestService.ResultsByRaceAsync(_year, _round);
                    original.Results = res.Results;
                }

                // Only gets qualifying if not provided.
                if (original?.Qualifying == null)
                {
                    var q = await App.RestService.QualifyingByRaceAsync(_year, _round);
                    original.Qualifying = q?.Qualifying;
                }

                Race = original;
                Title = Race.Season + " " + Race.Name;

                // In function of the race, display one or others layouts.
                DisplayLayouts();
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
