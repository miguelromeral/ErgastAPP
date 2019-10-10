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
	public partial class DriversPage : ContentPage
	{
        DriversViewModel viewModel;

		public DriversPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DriversViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {

            var item = args.SelectedItem as Driver;
            if (item == null)
                return;
            
            await Navigation.PushAsync(new DriverDetailPage(new DriverDetailViewModel(item.Id)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
        

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue.ToString()))
                viewModel.LoadItemsFromData();
            else
                viewModel.LoadItemsFromData(e.NewTextValue.ToString());
        }


        void ShowReport_Clicked(object sender, SelectedItemChangedEventArgs args)
        {
            var selectedLocation = viewModel.Items.First(item => item.Id == (sender as Button).CommandParameter.ToString());

            Device.OpenUri(new Uri(selectedLocation.URL));
        }
    }
}