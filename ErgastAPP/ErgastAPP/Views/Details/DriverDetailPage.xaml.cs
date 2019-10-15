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

namespace ErgastAPP.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DriverDetailPage : ContentPage
	{
        DriverDetailViewModel viewModel;

		public DriverDetailPage (DriverDetailViewModel viewModel)
		{
			InitializeComponent ();
            
            BindingContext = this.viewModel = viewModel;
        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            viewModel.LoadItemsCommand.Execute(null);
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
            Navigator.OpenSeasons(this, SeasonOrigin.DriverWorldChampion, viewModel.SeasonsWorldChampions, viewModel.Item);
        }

        private void Seasons_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenSeasons(this, SeasonOrigin.DriverSeasons, viewModel.Seasons, viewModel.Item);
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