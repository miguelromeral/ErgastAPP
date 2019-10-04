using ErgastAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ErgastAPP.ViewModels
{
    public class SeasonViewModel : BaseViewModel
    {
        public ObservableCollection<Season> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public SeasonViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Season>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                DataErgastSeasons data = await App.RestService.GetSeasonsDataAsync(App.API.Seasons) as DataErgastSeasons;
                foreach (var item in data.SeasonTable.Seasons)
                {
                    Items.Add(item);
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
