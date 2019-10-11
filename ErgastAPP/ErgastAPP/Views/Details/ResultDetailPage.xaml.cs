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
	public partial class ResultDetailPage : ContentPage
	{
        ResultDetailViewModel viewModel;

		public ResultDetailPage (ResultDetailViewModel viewModel)
		{
			InitializeComponent ();

            BindingContext = this.viewModel = viewModel;
		}


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Result == null)
                viewModel.LoadItemsCommand.Execute(null);
        }



        private void Driver_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Result != null)
            {
                Navigation.PushAsync(new DriverDetailPage(new DriverDetailViewModel(viewModel.Result.Driver)));
            }
            else
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
        }

        private void Constructor_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Result != null)
            {
                Navigation.PushAsync(new ConstructorDetailPage(new ConstructorDetailViewModel(viewModel.Result.Constructor)));
            }
            else
                DisplayAlert("Data not available yet", "Please, wait until the data is successfully loaded", "OK");
        }
    }
}