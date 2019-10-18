using ErgastAPP.Models;
using ErgastAPP.Services;
using ErgastAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microcharts.Forms;
using SkiaSharp;
using Microcharts;
using ErgastAPP.Resources;

namespace ErgastAPP.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DriverDetailPage : ContentPage
	{
        DriverDetailViewModel viewModel;

        List<Microcharts.Entry> EntriesRaces;
        List<Microcharts.Entry> EntriesRacesPerTeam;


        public DriverDetailPage (DriverDetailViewModel viewModel)
		{
			InitializeComponent ();

            EntriesRaces = new List<Microcharts.Entry>();
            EntriesRacesPerTeam = new List<Microcharts.Entry>();
            viewModel.Page = this;
            BindingContext = this.viewModel = viewModel;
            
        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Item == null)
            {
                viewModel.LoadItemsCommand.Execute(null);
                
            }
        }


        public void LoadEntriesTeams()
        {
            EntriesRacesPerTeam.Clear();
            Dictionary<string, int> entries = new Dictionary<string, int>();
            Dictionary<string, string> constructors = new Dictionary<string, string>();
            foreach (var r in viewModel.Races.Races)
            {
                var result = r.Results[0];
                string team = result.Constructor.Name;
                if (!entries.Keys.Contains(team))
                {
                    entries.Add(team, 1);
                    constructors.Add(team, result.Constructor.Id);
                }
                else
                {
                    int value = 0;
                    if (entries.TryGetValue(team, out value))
                    {
                        entries.Remove(team);
                        entries.Add(team, value + 1);
                    }
                }
            }

            foreach (KeyValuePair<string, int> entry in entries)
            {
                string id = "";
                constructors.TryGetValue(entry.Key, out id);
                EntriesRacesPerTeam.Add(new Microcharts.Entry(entry.Value)
                {
                    Label = entry.Key,
                    ValueLabel = entry.Value.ToString(),

                    Color = SKColor.Parse(Colors.GetColorByTeam(id)),
                });
            }
            chartTeams.Chart = new DonutChart()
            {
                HoleRadius = 0.3f,
                Entries = EntriesRacesPerTeam,
                BackgroundColor = SKColor.Parse("#303030")
            };
        }

        public void LoadEntries(int total, int wins, int poles, int podiums, int outs)
        {
            EntriesRaces.Add(new Microcharts.Entry(total)
            {
                Label = "Races",
                ValueLabel = total.ToString(),
                Color = SKColor.Parse("#dddddd")
            });
            EntriesRaces.Add(new Microcharts.Entry(podiums)
            {
                Label = "Podiums",
                ValueLabel = podiums.ToString(),
                Color = SKColor.Parse("#3b8cff")
            });
            EntriesRaces.Add(new Microcharts.Entry(poles)
            {
                Label = "Poles",
                ValueLabel = poles.ToString(),
                Color = SKColor.Parse("#e114ff")
            });
            EntriesRaces.Add(new Microcharts.Entry(wins)
            {
                Label = "Wins",
                ValueLabel = wins.ToString(),
                Color = SKColor.Parse("#1be02b")
            });
            EntriesRaces.Add(new Microcharts.Entry(outs)
            {
                Label = "Not Finished",
                ValueLabel = outs.ToString(),
                Color = SKColor.Parse("#111111")
            });


            chartRaces.Chart = new RadialGaugeChart()
            {
                Entries = EntriesRaces,
                BackgroundColor = SKColor.Parse("#303030")
            };
        }

        private void ReportButton_Clicked(object sender, EventArgs e)
        {
            if(viewModel.Item != null)
                Device.OpenUri(new Uri(viewModel.Item.URL));
        }

        private void Races_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenRaces(this, RaceOrigin.DriverRaces, viewModel.Races, viewModel.Item);
        }

        private void RacesPoles_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenRaces(this, RaceOrigin.DriverPoles, viewModel.Races, viewModel.Item);
        }

        private void RacesWon_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenRaces(this, RaceOrigin.DriverWins, viewModel.Races, viewModel.Item);
        }

        private void WorldChampion_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenSeasons(this, viewModel.SeasonsWorldChampions, viewModel.Item.FamilyName + " World Champion");
        }

        private void Seasons_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenSeasons(this, viewModel.Seasons, viewModel.Item.FamilyName + " Seasons");
        }

        private void Podiums_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenRaces(this, RaceOrigin.DriverPodiums, viewModel.Races, viewModel.Item);
        }

        private void Constructors_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenConstructor(this, ConstructorOrigin.Drivers, viewModel.Constructors, viewModel.Item);
        }

        private void FastestLaps_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenRaces(this, RaceOrigin.DriverFastestLaps, viewModel.FastestLaps, viewModel.Item);
        }
    }
}