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
	public partial class HomePage : ContentPage
	{
        HomeViewModel viewModel;

		public HomePage()
		{
			InitializeComponent();

            BindingContext = this.viewModel = new HomeViewModel();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.lastrace == null)
                viewModel.LoadItemsCommand.Execute(null);
        }


        private void LastRace_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenRaceDetail(this, viewModel.lastrace);
        }

        private void Driver_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenDriverDetail(this, (sender as Button).CommandParameter.ToString());
        }

        private void Constructor_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenConstructorDetail(this, (sender as Button).CommandParameter.ToString());
        }
    }
}