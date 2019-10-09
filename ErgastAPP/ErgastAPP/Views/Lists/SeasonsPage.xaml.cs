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
	public partial class SeasonsPage : ContentPage
	{
        SeasonViewModel viewModel;

		public SeasonsPage()
		{
			InitializeComponent();
            
            BindingContext = viewModel = new SeasonViewModel();
        }


        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Season;
            if (item == null)
                return;

            await Navigation.PushAsync(new RacePage(new RaceViewModel(item)));

            // Manually deselect item.
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
            if (viewModel.Items != null && viewModel.Items.Count != 0)
            {
                if (string.IsNullOrWhiteSpace(e.NewTextValue.ToString()))
                    viewModel.LoadItemsFromData();
                else
                    viewModel.LoadItemsFromData(e.NewTextValue.ToString());
            }
        }

        //void ShowReport_Clicked(object sender, SelectedItemChangedEventArgs args)
        //{
        //    var item = args.SelectedItem as Button;
        //    var aux = item.Parent;


        //    var item = args.SelectedItem as Season;
        //    if (item == null)
        //        return;

        //    Device.OpenUri(new Uri(item.URL));

        //    // Manually deselect item.
        //    ItemsListView.SelectedItem = null;
        //}
    }
}