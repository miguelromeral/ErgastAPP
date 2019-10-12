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
            
            viewModel.LoadItemsCommand.Execute(null);
        }

        private void Maps_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(viewModel.Circuit.GoogleMapsURI));
        }


        private void Races_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Races != null && viewModel.Circuit != null)
            {
                Navigation.PushAsync(new RacePage(new RaceViewModel(viewModel.Races, viewModel.Circuit.Name + " Races")));
            }
            else
            {
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
            }
        }
    }
}