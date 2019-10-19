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
	public partial class CircuitDetailPage : ContentPage
	{
        CircuitDetailViewModel viewModel;

        public CircuitDetailPage(CircuitDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            if(viewModel.Circuit == null)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void Maps_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(viewModel.Circuit.GoogleMapsURI));
        }


        private void Races_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenRaces(this, Models.RaceOrigin.CircuitRaces, viewModel.Races, viewModel.Circuit);
        }


        private void ReportButton_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Circuit != null)
                Device.OpenUri(new Uri(viewModel.Circuit.URL));
        }

        private void Winners_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenDriver(this, viewModel.DriverWinners, viewModel.Circuit?.Name + " Winners");
        }
    }
}