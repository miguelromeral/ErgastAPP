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
		}


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Race == null)
                viewModel.LoadItemsCommand.Execute(null);
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
                Navigation.PushAsync(new ResultsDetailPage(new ResultDetailViewModel(viewModel.Race, viewModel._year)));
            }
            else
            {
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
            }
        }

        private async void Qualy_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QualyDetailPage(new QualyDetailViewModel(viewModel.Race, viewModel._year)));
        }

        private async void DriverStandings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DriverStandingDetailPage(new DriverStandingDetailViewModel(viewModel.Race, viewModel._year)));
        }
    }
}