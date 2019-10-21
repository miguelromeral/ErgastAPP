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
    /// ViewModel for Circuit Detail page.
    /// </summary>
    /// <seealso cref="ErgastAPP.ViewModels.BaseViewModel" />
    public class CircuitDetailViewModel : BaseViewModel
    {
        /// <summary>
        /// Command to load all the data in the page.
        /// </summary>
        /// <value>
        /// The load items command.
        /// </value>
        public Command LoadItemsCommand { get; set; }

        /// <summary>
        /// The circuit
        /// </summary>
        private Circuit _circuit;
        /// <summary>
        /// Gets or sets the circuit.
        /// </summary>
        /// <value>
        /// The circuit.
        /// </value>
        public Circuit Circuit { get { return _circuit; } set { SetProperty(ref _circuit, value); } }

        /// <summary>
        /// The original circuit data.
        /// It contains the instance passed by the user.
        /// </summary>
        Circuit dataoriginal;

        /// <summary>
        /// All races a circuit had held.
        /// </summary>
        private RaceTable _races;
        /// <summary>
        /// Gets or sets the races.
        /// </summary>
        /// <value>
        /// The races.
        /// </value>
        public RaceTable Races { get { return _races; } set { SetProperty(ref _races, value); } }

        /// <summary>
        /// The driver ever winners.
        /// </summary>
        private DriverTable _winners;
        /// <summary>
        /// Gets or sets the driver winners.
        /// </summary>
        /// <value>
        /// The driver winners.
        /// </value>
        public DriverTable DriverWinners { get { return _winners; } set { SetProperty(ref _winners, value); } }


        /// <summary>
        /// Initializes a new instance of the <see cref="CircuitDetailViewModel"/> class.
        /// </summary>
        /// <param name="circuit">The circuit.</param>
        public CircuitDetailViewModel(Circuit circuit)
        {
            dataoriginal = circuit;
            Title = dataoriginal.Name;

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
                Races = await App.RestService.RacesByCircuit(dataoriginal.Id);
                DriverWinners = await App.RestService.GetDriversWinnerCircuitAsync(dataoriginal.Id);
                Circuit = dataoriginal;
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
