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
	public partial class RacePage : ContentPage
	{
        RaceViewModel viewModel;

		public RacePage(RaceViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        
        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            Navigator.OpenRaceDetail(this, args.SelectedItem as Race);
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
            Device.OpenUri(new Uri((sender as Button).CommandParameter.ToString()));
        }
    }
}