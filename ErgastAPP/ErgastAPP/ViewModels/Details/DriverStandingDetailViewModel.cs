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
    /// <summary>
    /// ViewModel for Driver Standings page.
    /// </summary>
    /// <seealso cref="ErgastAPP.ViewModels.BaseViewModel" />
    public class DriverStandingDetailViewModel : BaseViewModel
    {
        /// <summary>
        /// Every row of the standings.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public ObservableCollection<DriverStandings> Items { get; set; }

        /// <summary>
        /// Command to load all the data in the page.
        /// </summary>
        /// <value>
        /// The load items command.
        /// </value>
        public Command LoadItemsCommand { get; set; }

        /// <summary>
        /// The race that the standings belongs.
        /// </summary>
        public Race Race;

        /// <summary>
        /// The standings table.
        /// </summary>
        private StandingsTable _standings;
        /// <summary>
        /// Gets or sets the standings.
        /// </summary>
        /// <value>
        /// The standings.
        /// </value>
        public StandingsTable Standings { get { return _standings; } set { SetProperty(ref _standings, value); } }

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverStandingDetailViewModel"/> class.
        /// </summary>
        /// <param name="race">The race</param>
        public DriverStandingDetailViewModel(Race race)
        {
            Race = race;

            Items = new ObservableCollection<DriverStandings>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        /// <summary>
        /// Executes the load items command.
        /// </summary>
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Standings = await App.RestService.DriverStandingsByRace(Race.Season, Race.Round);

                Title = Race.Season + " " + Race.Name;

                Items.Clear();
                foreach (var r in Standings.Standings[0].DriverStandings.OrderBy(x => x.Position).ThenBy(x => x.Wins))
                {
                    Items.Add(r);
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