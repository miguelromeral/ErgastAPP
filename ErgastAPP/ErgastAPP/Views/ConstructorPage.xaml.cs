﻿using ErgastAPP.ViewModels;
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
	public partial class ConstructorPage : ContentPage
	{
        ConstructorViewModel viewModel;

		public ConstructorPage ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new ConstructorViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {

            //var item = args.SelectedItem as Driver;
            //if (item == null)
            //    return;

            //await Navigation.PushAsync(new DriverDetailPage(new DriverDetailViewModel(item.Id)));

            //// Manually deselect item.
            //ItemsListView.SelectedItem = null;

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue.ToString()))
                viewModel.LoadItemsFromData();
            else
                viewModel.LoadItemsFromData(e.NewTextValue.ToString());
            
        }
    }
}