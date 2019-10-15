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
	public partial class SeasonsPage : ContentPage
	{
        SeasonViewModel viewModel;

		public SeasonsPage(SeasonViewModel viewModel)
		{
			InitializeComponent();
            
            BindingContext = this.viewModel = viewModel;
        }


        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            Navigator.OpenRaces(this, args.SelectedItem as Season, false);
            ItemsListView.SelectedItem = null;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }



        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (viewModel.Items != null)
            {
                if (string.IsNullOrWhiteSpace(e.NewTextValue.ToString()))
                    viewModel.LoadItemsFromData();
                else
                    viewModel.LoadItemsFromData(e.NewTextValue.ToString());
            }
        }



        void ShowReport_Clicked(object sender, SelectedItemChangedEventArgs args)
        {
            var selectedLocation = viewModel.Items.First(item => item.Year == int.Parse((sender as Button).CommandParameter.ToString()));

            Device.OpenUri(new Uri(selectedLocation.URL));
        }
    }
}