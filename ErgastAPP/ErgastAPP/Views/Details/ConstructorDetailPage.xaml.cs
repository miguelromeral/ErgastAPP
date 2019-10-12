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
            
            viewModel.LoadItemsCommand.Execute(null);
        }


        private void Races_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Constructor != null && viewModel.Races != null)
                Navigation.PushAsync(new RacePage(new RaceViewModel(viewModel.Races, viewModel.Constructor.Name + " Races")));
            else
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
        }
        
        private void RacesPoles_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Constructor != null && viewModel.Races != null)
            {
                var table = new RaceTable();
                table.Races = viewModel.Races.RacesPolePosition;

                Navigation.PushAsync(new RacePage(new RaceViewModel(table, viewModel.Constructor.Name + " Pole positions")));
            }
            else
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
        }

        private void RacesWon_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Constructor != null && viewModel.Races != null)
            {
                var table = new RaceTable();
                table.Races = viewModel.Races.RacesWon;

                Navigation.PushAsync(new RacePage(new RaceViewModel(table, viewModel.Constructor.Name + " Wins")));
            }
            else
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
        }

        private void Podiums_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Constructor != null && viewModel.Races != null)
            {
                var table = new RaceTable();
                table.Races = viewModel.Races.RacesPodiums;

                Navigation.PushAsync(new RacePage(new RaceViewModel(table, viewModel.Constructor.Name + " Podiums")));
            }
            else
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
        }


        private void WorldChampion_Clicked(object sender, EventArgs e)
        {
            if (viewModel.SeasonsWorldChampions != null && viewModel.Constructor != null)
            {
                Navigation.PushAsync(new SeasonsPage(new SeasonViewModel(viewModel.SeasonsWorldChampions, viewModel.Constructor.Name + " World Champions")));
            }
            else
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
        }


        private void Drivers_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Drivers != null && viewModel.Constructor != null)
            {
                Navigation.PushAsync(new DriversPage(new DriversViewModel(viewModel.Drivers, viewModel.Constructor.Name + " Drivers")));
            }
            else
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
        }
    }
}