using ErgastAPP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ErgastAPP.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        string last;
        public string Last { get { return last; } set { SetProperty(ref last, value); } }


        public Race lastrace;

        public HomeViewModel()
        {
            Title = "F1 Stats";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                lastrace = await App.RestService.GetLastRaceAsync();
                Last = lastrace.Season + " " + lastrace.Name;
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
