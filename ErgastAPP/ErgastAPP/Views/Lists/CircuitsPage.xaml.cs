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
	public partial class CircuitsPage : ContentPage
	{
        CircuitViewModel viewModel;

		public CircuitsPage ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new CircuitViewModel();
        }


        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {

            var item = args.SelectedItem as Circuit;
            if (item == null)
                return;

            var uri = new Uri(String.Format("https://www.google.com/maps/search/?api=1&query={0},{1}", item.Location.Latitud,item.Location.Longitud));
            Device.OpenUri(uri);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void PickerYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                viewModel.YearPicked = Convert.ToInt32(pickerYear.SelectedItem);
            }
            catch (Exception)
            {
                viewModel.YearPicked = null;
            }

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