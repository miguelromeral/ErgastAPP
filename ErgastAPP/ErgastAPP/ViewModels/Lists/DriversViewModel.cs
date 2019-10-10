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
   
        DataErgastDrivers _drivers;

        public static string ALL_TEXT = "All";

        public DriversViewModel()
        {
            Title = "Drivers";
            Items = new ObservableCollection<Driver>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                _drivers = await App.RestService.GetDriversAsync();
                _drivers.DriverTable.Drivers = _drivers.DriverTable.Drivers.OrderBy(o => o.Fullname).ToList();
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
            foreach (var item in _drivers.DriverTable.Drivers.Where(i => i.Fullname.ToLower().Contains(content.ToLower()) ||
            i.Nationality.ToLower().Contains(content.ToLower()) || i.Number.ToString().Contains(content.ToLower())))
            {
                Items.Add(item);
            }
        }

        
    }
}
