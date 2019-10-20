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
	public partial class DriversPage : ContentPage
	{
        DriversViewModel viewModel;

		public DriversPage(DriversViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            Navigator.OpenDriverDetail(this, args.SelectedItem as Driver, false);
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
            if (viewModel.Items != null)
            {
                if (string.IsNullOrWhiteSpace(e.NewTextValue.ToString()))
                    viewModel.LoadItemsFromData();
                else
                    viewModel.LoadItemsFromData(e.NewTextValue.ToString());
            }
        }


        async void ShowReport_Clicked(object sender, EventArgs args)
        {
            var selectedLocation = viewModel.Items.First(item => item.Id == (sender as Button).CommandParameter.ToString());

            Device.OpenUri(new Uri(selectedLocation.URL));
        }
    }
}