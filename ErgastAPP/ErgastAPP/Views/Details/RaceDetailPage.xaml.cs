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
            if (viewModel.Race != null)
            {
                Navigation.PushAsync(new ResultsPage(new ResultViewModel(viewModel.Race)));
            }
            else
            {
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
            }
        }

        private void Qualy_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Race != null)
                Navigation.PushAsync(new QualyPage(new QualyViewModel(viewModel.Race, viewModel._year)));
            else
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
        }

        private void DriverStandings_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Race != null)
                Navigation.PushAsync(new DriverStandingDetailPage(new DriverStandingDetailViewModel(viewModel.Race, viewModel._year)));
            else
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
        }

        private void ConstructorStandings_Clicked(object sender, EventArgs e)
        {
            if(viewModel.Race == null)
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
            else
                if(viewModel.Race?.Season >= 1958)
                    Navigation.PushAsync(new ConstructorStandingDetailPage(new ConstructorStandingDetailViewModel(viewModel.Race, viewModel._year)));
                else
                    DisplayAlert("Constructor Standings Missing", "The Constructor Championship wasn't be awarded since 1958.", "OK");
        }


        private void Circuit_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenCircuitDetail(this, viewModel?.Race?.Circuit);
        }
        
        void Driver_Clicked(object sender, SelectedItemChangedEventArgs args)
        {
            Navigator.OpenDriverDetail(this, (sender as Button).CommandParameter as Driver);
        }

        void Constructor_Clicked(object sender, SelectedItemChangedEventArgs args)
        {
            Navigation.PushAsync(new ConstructorDetailPage(new ConstructorDetailViewModel((sender as Button).CommandParameter.ToString())));
        }

        private void Evolution_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EvolutionPage(new EvolutionViewModel(viewModel.Race)));
        }
    }
}