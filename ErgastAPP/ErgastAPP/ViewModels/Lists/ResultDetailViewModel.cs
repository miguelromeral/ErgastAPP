using ErgastAPP.Models;
using ErgastAPP.Views;
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
    public class ResultViewModel : BaseViewModel
    {
        public ObservableCollection<Result> Items { get; set; }

        public Command LoadItemsCommand { get; set; }

        private Race _race;
        public Race Race { get { return _race; } set { SetProperty(ref _race, value); } }
       

        public ResultsPage Page { get; set; }

        public ResultViewModel(Race r)
        {
            Race = r;

            Items = new ObservableCollection<Result>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var aux = await App.RestService.ResultsByRaceAsync(Race.Season, Race.Round);
                Race.Results = aux.Results;

                Title = Race.Season + " " + Race.Name;

                Items.Clear();
                foreach(var r in Race.Results.OrderBy(x => x.Position))
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
