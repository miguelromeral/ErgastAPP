﻿using ErgastAPP.Models;
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

            //Device.OpenUri(new Uri(item.URL));
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

        private void PickerYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                viewModel.YearPicked = Convert.ToInt32(pickerYear.SelectedItem);
            }catch(Exception)
            {
                viewModel.YearPicked = null;
            }
            viewModel.Rounds.Clear();
            viewModel.RoundPicked = null;
            viewModel.Racename = viewModel.YearPicked +  " Season";
            // This sould be removed if the binding works fine.
            labelRace.Text = viewModel.Racename;

            viewModel.LoadItemsCommand.Execute(null);
        }

        private void PickerRound_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewModel.RoundPicked = Convert.ToInt32(pickerRound.SelectedItem);
            viewModel.SetGPInfo();

            viewModel.LoadItemsCommand.Execute(null);

            // This sould be removed if the binding works fine.
            labelRace.Text = viewModel.Racename;
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue.ToString()))
                viewModel.LoadItemsFromData();
            else
                viewModel.LoadItemsFromData(e.NewTextValue.ToString());
        }
    }
}