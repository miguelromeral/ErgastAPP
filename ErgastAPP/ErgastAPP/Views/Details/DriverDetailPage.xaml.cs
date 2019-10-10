using ErgastAPP.Models;
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

            if (viewModel.Item == null)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void ReportButton_Clicked(object sender, EventArgs e)
        {
            if(viewModel.Item != null)
                Device.OpenUri(new Uri(viewModel.Item.URL));
        }

        private void Races_Clicked(object sender, EventArgs e)
        {
            if(viewModel.Item != null && viewModel.Races != null)
                Navigation.PushAsync(new RacePage(new RaceViewModel(viewModel.Item, viewModel.Races, viewModel.Item.Fullname + " Races")));
            else
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
        }

        private void RacesPoles_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Item != null && viewModel.Races != null)
            {
                var table = new RaceTable();
                table.Races = viewModel.Races.RacesPolePosition;

                Navigation.PushAsync(new RacePage(new RaceViewModel(viewModel.Item, table, viewModel.Item.Fullname + " Pole positions")));
            }
            else
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
        }

        private void RacesWon_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Item != null && viewModel.Races != null)
            {
                var table = new RaceTable();
                table.Races = viewModel.Races.RacesWon;

                Navigation.PushAsync(new RacePage(new RaceViewModel(viewModel.Item, table, viewModel.Item.Fullname + " Wins")));
            }
            else
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
        }

        private void WorldChampion_Clicked(object sender, EventArgs e)
        {
            if (viewModel.SeasonsWorldChampions != null && viewModel.Item != null)
            {
                Navigation.PushAsync(new SeasonsPage(new SeasonViewModel(viewModel.SeasonsWorldChampions, viewModel.Item.Fullname + " World Champions")));
            }
            else
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
        }
    }
}