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
	public partial class RaceDetailPage : ContentPage
	{
        RaceDetailViewModel viewModel;

		public RaceDetailPage (RaceDetailViewModel viewModel)
		{
			InitializeComponent ();

            BindingContext = this.viewModel = viewModel;
            viewModel.LayoutQualy = layoutQualifying;
            viewModel.LayoutFastestLap = layoutFastestLap;
            viewModel.ButtonRaceEvolution = bRaceEvolution;
            viewModel.ButtonConstructorStandings = bConstructorStandings;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            layoutQualifying.IsVisible = false;
            layoutFastestLap.IsVisible = false;
            bRaceEvolution.IsVisible = false;
            bConstructorStandings.IsVisible = false;
            
            if(viewModel.Race == null)
                viewModel.LoadItemsCommand.Execute(null);
            
            viewModel.DisplayLayouts();
        }

        private void ReportButton_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Race != null)
                Device.OpenUri(new Uri(viewModel.Race.URL));
        }

        private void Results_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenResult(this, viewModel?.Race);
        }

        private void Qualy_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenQualy(this, viewModel?.Race);
        }

        private void DriverStandings_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenDriverStandings(this, viewModel.Race);
        }

        private void ConstructorStandings_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenConstructorStandings(this, viewModel.Race);
        }

        private void Circuit_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenCircuitDetail(this, viewModel?.Race?.Circuit);
        }
        
        private void Driver_Clicked(object sender, EventArgs args)
        {
            Navigator.OpenDriverDetail(this, (sender as Button).CommandParameter as Driver);
        }

        private void Constructor_Clicked(object sender, EventArgs args)
        {
            Navigator.OpenConstructorDetail(this, (sender as Button).CommandParameter as Constructor);
        }

        private void Evolution_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenEvolution(this, viewModel.Race);
        }
    }
}