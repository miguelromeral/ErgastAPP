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
    /// ViewModel for circuit list.
    /// </summary>
    /// <seealso cref="ErgastAPP.ViewModels.BaseViewModel" />
    public class CircuitViewModel : BaseViewModel
    {
        /// <summary>
        /// List of the circuits.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public ObservableCollection<Circuit> Items { get; set; }

        /// <summary>
        /// Command to load the items.
        /// </summary>
        /// <value>
        /// The load items command.
        /// </value>
        public Command LoadItemsCommand { get; set; }

        /// <summary>
        /// The original data of circuits.
        /// </summary>
        CircuitTable _circuits;

        /// <summary>
        /// Initializes a new instance of the <see cref="CircuitViewModel"/> class.
        /// </summary>
        public CircuitViewModel()
        {
            Title = "Circuits";
            Items = new ObservableCollection<Circuit>();
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
                _circuits = await App.RestService.GetCircuitsAsync();
                _circuits.Circuits = _circuits.Circuits.OrderBy(o => o.Name).ToList();
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

        /// <summary>
        /// Loads the items from data given a criteria to search for.
        /// </summary>
        /// <param name="content">Criteria to look for.</param>
        public void LoadItemsFromData(string content = "")
        {
            Items.Clear();
            foreach (var item in _circuits.Circuits.Where(i => i.Name.ToLower().Contains(content.ToLower()) || 
            i.Location.Address.ToLower().Contains(content.ToLower())))
            {
                Items.Add(item);
            }
        }
    }
}
