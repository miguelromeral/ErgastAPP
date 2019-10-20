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

        private Race original;


        public StackLayout LayoutQualy { get; set; }
        public StackLayout LayoutFastestLap { get; set; }
        public Button ButtonRaceEvolution { get; set; }
        public Button ButtonConstructorStandings { get; set; }


        RaceOrigin origin;

        public RaceDetailViewModel(int year, int round)
        {
            _year = year;
            _round = round;
            origin = RaceOrigin.YearRound;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        
        public RaceDetailViewModel(Race race)
        {
            _year = race.Season;
            _round = race.Round;
            original = race;
            origin = RaceOrigin.Provided;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }



        public void DisplayLayouts()
        {
            if(Race?.Season != null)
            {
                if (Race.Season >= 1958)
                {
                    ButtonConstructorStandings.IsVisible = true;
                    if (Race.Season >= 1996)
                    {
                        ButtonRaceEvolution.IsVisible = true;
                        if (Race.Season >= 2003)
                        {
                            LayoutQualy.IsVisible = true;
                            if (Race.Season >= 2004)
                            {
                                LayoutFastestLap.IsVisible = true;
                            }
                        }
                    }
                }
            }
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Race = null;
                switch (origin)
                {
                    case RaceOrigin.YearRound:
                        if (Race == null)
                        {
                            var data = await App.RestService.GetRaceResultsAsync(_year, _round);
                            original = data.Races[0];
                        }
                        break;
                    case RaceOrigin.Provided:
                    default:
                        break;
                }
                
                // We retrieve the results without checks because the original race could
                // have the results only for the constructors/drivers results.
                var res = await App.RestService.ResultsByRaceAsync(_year, _round);
                original.Results = res.Results;
                

                if (original?.Qualifying == null)
                {
                    var q = await App.RestService.QualifyingByRaceAsync(_year, _round);
                    original.Qualifying = q?.Qualifying;
                }

                Race = original;
                Title = _year + " " + Race.Name;
                DisplayLayouts();
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
