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
	public partial class ConstructorDetailPage : ContentPage
    {
        ConstructorDetailViewModel viewModel;

        public ConstructorDetailPage(ConstructorDetailViewModel constructorDetailViewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = constructorDetailViewModel;
        }
        

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            if(viewModel.Constructor == null)
                viewModel.LoadItemsCommand.Execute(null);
        }


        private void Races_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenRaces(this, RaceOrigin.ConstructorRaces, viewModel.Races, viewModel.Constructor);
        }
        
        private void RacesPoles_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenRaces(this, RaceOrigin.ConstructorPoles, viewModel.Races, viewModel.Constructor);
        }

        private void RacesWon_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenRaces(this, RaceOrigin.ConstructorFastestLaps, viewModel.Races, viewModel.Constructor);
        }

        private void Podiums_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenRaces(this, RaceOrigin.ConstructorFastestLaps, viewModel.FastestLaps, viewModel.Constructor);
        }
        
        private void WorldChampion_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenSeasons(this, SeasonOrigin.ConstructorWorldChampion, viewModel.SeasonsWorldChampions, viewModel.Constructor);
        }
        
        private void Drivers_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenDriver(this, DriverOrigin.Constructors, viewModel.Drivers, viewModel.Constructor);
        }
        
        private void FastestLaps_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenRaces(this, RaceOrigin.ConstructorFastestLaps, viewModel.FastestLaps, viewModel.Constructor);
        }

        private void ReportButton_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Constructor != null)
                Device.OpenUri(new Uri(viewModel.Constructor.URL));
        }
    }
}