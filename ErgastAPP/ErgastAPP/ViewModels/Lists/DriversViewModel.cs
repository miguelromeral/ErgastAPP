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
    /// ViewModel for drivers list page.
    /// </summary>
    /// <seealso cref="ErgastAPP.ViewModels.BaseViewModel" />
    public class DriversViewModel : BaseViewModel
    {
        /// <summary>
        /// List of drivers to show.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public ObservableCollection<Driver> Items { get; set; }

        /// <summary>
        /// Main command to load the page.
        /// </summary>
        /// <value>
        /// The load items command.
        /// </value>
        public Command LoadItemsCommand { get; set; }

        /// <summary>
        /// Original list of drivers.
        /// </summary>
        DriverTable _drivers;

        /// <summary>
        /// Indicates if the drivers list is not provided.
        /// </summary>
        private const string _origin_notprovided = "NotProvided";

        /// <summary>
        /// Initializes a new instance of the <see cref="DriversViewModel"/> class for display all drivers.
        /// </summary>
        public DriversViewModel()
        {
            Title = "Drivers";
            Items = new ObservableCollection<Driver>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(_origin_notprovided));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DriversViewModel"/> class for display only the drivers passed as arguments.
        /// </summary>
        /// <param name="drivers">The driver list</param>
        /// <param name="title">Title of the content page.</param>
        public DriversViewModel(DriverTable drivers, string title)
        {
            _drivers = drivers;
            Title = title;
            Items = new ObservableCollection<Driver>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        /// <summary>
        /// Executes the load items command.
        /// </summary>
        /// <param name="source">The source.</param>
        async Task ExecuteLoadItemsCommand(string source = "")
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                if(source ==_origin_notprovided)
                    _drivers = await App.RestService.GetDriversAsync();
                    
                _drivers.Drivers = _drivers.Drivers.OrderBy(o => o.Fullname).ToList();
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
        /// Loads the items from data given a criteria to look for.
        /// </summary>
        /// <param name="content">The content to search.</param>
        public void LoadItemsFromData(string content = "")
        {
            Items.Clear();
            foreach (var item in _drivers.Drivers.Where(i => i.Fullname.ToLower().Contains(content.ToLower()) ||
            i.Nationality.ToLower().Contains(content.ToLower()) || i.Number.ToString().Contains(content.ToLower())))
            {
                Items.Add(item);
            }
        }
    }
}
