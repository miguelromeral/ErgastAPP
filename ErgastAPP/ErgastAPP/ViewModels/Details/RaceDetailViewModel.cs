using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ErgastAPP.Models;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ErgastAPP.ViewModels
{
    public class RaceDetailViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        private Race _race;
        public Race Race { get { return _race; } set { SetProperty(ref _race, value); } }

        public int _year;
        public int _round;


        public StackLayout LayoutQualy { get; set; }
        public StackLayout LayoutFastestLap { get; set; }


        public RaceDetailViewModel(int year, int round)
        {
            _year = year;
            _round = round;

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Race r = null;

                var data = await App.RestService.GetRaceResultsAsync(_year, _round);
                r = data.RaceTable.Races[0];

                var res = await App.RestService.ResultsByRaceAsync(_year, _round);
                r.Results = res.Results;

                
                var q = await App.RestService.QualifyingByRaceAsync(_year, _round);
                if (q != null)
                {
                    r.Qualifying = q.Qualifying;
                    if (r.Season >= 2003)
                        LayoutQualy.IsVisible = true;
                }

                if(r.Season >= 2004)
                {
                    LayoutFastestLap.IsVisible = true;
                }


                Race = r;

                Title = _year + " " + Race.Name;
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
