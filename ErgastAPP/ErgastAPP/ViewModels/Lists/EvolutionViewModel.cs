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
    public class EvolutionViewModel : BaseViewModel
    {

        public ObservableCollection<EvolutionRaceRow> Items { get; set; }
        public Command LoadItemsCommand { get; set; }


        public Slider Slider;

        private string lap;
        public string Lap { get { return lap; } set { SetProperty(ref lap, value); } }



        public Race Race;

        public EvolutionViewModel(Race r)
        {
            Race = r;

            Title = r.Season + " " + r.Name + " Evolution";
            Items = new ObservableCollection<EvolutionRaceRow>();
            _rows = new List<EvolutionRaceRow>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }



        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var aux = await App.RestService.GetLapsByRace(Race.Season, Race.Round);
                Race.Laps = aux.Laps;

                Slider.Maximum = Race.Laps.Count - 1;

                InitRows();
                UpdateTable(1);
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

        List<EvolutionRaceRow> _rows;

        void InitRows()
        {
            _rows.Clear();
            Items.Clear();
            foreach(var r in Race.Results)
            {
                var row = new EvolutionRaceRow()
                {
                    Driver = r.Driver,
                    Constructor = r.Constructor
                };
                _rows.Add(row);
                Items.Add(row);
            }
        }


        public void UpdateTable(int lap)
        {
            Lap = "LAP: " + lap;

            try
            {
                if (Race.Laps != null)
                {
                    var aux = new ObservableCollection<EvolutionRaceRow>();
                    aux.Clear();
                    foreach (var l in Race.Laps.Where(x => x.Number == lap).FirstOrDefault().Timings.OrderBy(x => x.Position).ToList())
                    {
                        var row = Items.Where(x => x.Driver.Id == l.DriverId).FirstOrDefault();

                        if (row == null)
                        {
                            row = _rows.Where(x => x.Driver.Id == l.DriverId).FirstOrDefault();
                        }

                        row.Position = l.Position;
                        row.Time = l.Time;

                        aux.Add(row);
                    }
                    Items.Clear();
                    foreach (var i in aux.OrderBy(x => x.Position))
                    {
                        Items.Add(i);
                    }
                }
            }catch(Exception ex)
            {
                Lap = "DATA NO AVAILABLE";
            }
        }
    }
}
