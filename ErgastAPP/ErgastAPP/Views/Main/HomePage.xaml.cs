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
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();
		}


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RaceDetailPage(new RaceDetailViewModel(2019, 16)));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DriverDetailPage(new DriverDetailViewModel("alonso")));
        }

        private async void LastRace_Clicked(object sender, EventArgs e)
        {
            Race last = await App.RestService.GetLastRaceAsync();
            await Navigation.PushAsync(new RaceDetailPage(new RaceDetailViewModel(last.Season, last.Round)));
        }
    }
}