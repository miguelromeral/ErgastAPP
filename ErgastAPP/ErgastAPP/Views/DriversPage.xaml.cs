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
            //var item = args.SelectedItem as Season;
            //if (item == null)
            //    return;

            //DataErgastRaces data = await App.RestService.GetRacesBySeasonAsync(App.API.RacesBySeason(item.Year)) as DataErgastRaces;

            ////await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            //// Manually deselect item.
            //ItemsListView.SelectedItem = null;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void PickerYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewModel.YearPicked = Convert.ToInt32(pickerYear.SelectedItem);
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
    }
}