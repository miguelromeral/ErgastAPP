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

        public ObservableCollection<CustomRow> Items { get; set; }
        public Command LoadItemsCommand { get; set; }


        public Slider Slider;

        private string lap;
        public string Lap { get { return lap; } set { SetProperty(ref lap, value); } }



        public Race Race;

        public EvolutionViewModel(Race r)
        {
            Race = r;

            Title = r.Season + " " + r.Name + " Evolution";
            Items = new ObservableCollection<CustomRow>();
            _rows = new List<CustomRow>();
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

        List<CustomRow> _rows;

        void InitRows()
        {
            _rows.Clear();
            Items.Clear();
            foreach(var r in Race.Results)
            {
                var row = new CustomRow()
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

            if (Race.Laps != null)
            {
                var aux = new ObservableCollection<CustomRow>();
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
                foreach(var i in aux.OrderBy(x => x.Position))
                {
                    Items.Add(i);
                }
                
                //Items.OrderBy(x => x.Position);
            }


            //        Items.Clear();

            //foreach(var l in Race.Laps.Where(x => x.Number == lap).FirstOrDefault().Timings)
            //{
            //    var res = Race.Results.Where(x => x.Driver.Id == l.DriverId).Select(x => new { x.Driver, x.Constructor }).FirstOrDefault();
            //    var row = new CustomRow()
            //    {
            //        Position = l.Position,
            //        Driver = res.Driver,
            //        Constructor = res.Constructor,
            //        Time = l.Time
            //    };
            //    Items.Add(row);
            //}
        }


        public class CustomRow
        {
            public string Time { get; set; }
            public int Position { get; set; }
            public Driver Driver { get; set; }
            public Constructor Constructor { get; set; }
        }

    }
}
