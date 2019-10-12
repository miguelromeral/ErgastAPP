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
    public class DriversViewModel : BaseViewModel
    {
        public ObservableCollection<Driver> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
   
        DriverTable _drivers;

        public static string ALL_TEXT = "All";

        enum DataSource
        {
            All,
            Specified
        }

        DataSource _source;

        public DriversViewModel()
        {
            Title = "Drivers";
            Items = new ObservableCollection<Driver>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _source = DataSource.All;
        }


        public DriversViewModel(DriverTable dr, string title)
        {
            _drivers = dr;
            Title = title;
            Items = new ObservableCollection<Driver>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _source = DataSource.Specified;
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                switch (_source)
                {
                    case DataSource.All:
                        _drivers = await App.RestService.GetDriversAsync();
                        break;
                    case DataSource.Specified:
                    default:
                        break;
                }

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
