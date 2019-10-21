using ErgastAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace ErgastAPP.ViewModels
{
    /// <summary>
    /// ViewModel for the constructor list.
    /// </summary>
    /// <seealso cref="ErgastAPP.ViewModels.BaseViewModel" />
    public class ConstructorViewModel : BaseViewModel
    {
        /// <summary>
        /// List of constructors to display in the listview.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public ObservableCollection<Constructor> Items { get; set; }

        /// <summary>
        /// Main command to load the page content.
        /// </summary>
        /// <value>
        /// The load items command.
        /// </value>
        public Command LoadItemsCommand { get; set; }

        /// <summary>
        /// The original data.
        /// </summary>
        ConstructorTable _constructors;

        /// <summary>
        /// Indicates if the constructor has not been passed to the viewmodel.
        /// </summary>
        private const string _origin_notprovided = "NotProvided";

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructorViewModel"/> class displaying all constructors.
        /// </summary>
        public ConstructorViewModel()
        {
            Title = "Constructors";
            Items = new ObservableCollection<Constructor>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(_origin_notprovided));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructorViewModel"/> class given the list of constructors to display.
        /// </summary>
        /// <param name="data">Constructor table to print.</param>
        /// <param name="title">Title of the content page.</param>
        public ConstructorViewModel(ConstructorTable data, string title)
        {
            this._constructors = data;
            Title = title;
            Items = new ObservableCollection<Constructor>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        /// <summary>
        /// Executes the load items command.
        /// </summary>
        /// <param name="origin">The origin.</param>
        async Task ExecuteLoadItemsCommand(string origin = "")
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                // Only if data is not provided retrieve every one.
                if(origin == _origin_notprovided)
                    _constructors = await App.RestService.GetConstructorsAsync();

                _constructors.Constructors = _constructors.Constructors.OrderBy(o => o.Name).ToList();
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
        /// Display the list of constructor filtering by a string.
        /// </summary>
        /// <param name="content">Criteria to be searched.</param>
        public void LoadItemsFromData(string content = "")
        {
            Items.Clear();
            foreach (var item in _constructors.Constructors.Where(i => i.Name.ToLower().Contains(content.ToLower()) ||
            i.Nationality.ToLower().Contains(content.ToLower())))
            {
                Items.Add(item);
            }
        }
    }
}
