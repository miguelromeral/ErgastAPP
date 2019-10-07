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
	public partial class RacePage : ContentPage
	{
        RaceViewModel viewModel;

		public RacePage(RaceViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Race;
            if (item == null)
                return;
            
            await Navigation.PushAsync(new RaceDetailPage(new RaceDetailViewModel(item.Season, item.Round)));

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

        private async void ShowReport_Clicked(object sender, EventArgs e)
        {
            if(viewModel.Season != null)
                Device.OpenUri(new Uri(viewModel.Season.URL));
        }
    }
}