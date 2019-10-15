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

            if (viewModel.PitStops.Count == 0)
                viewModel.LoadStops.Execute(null);

            if (viewModel.Laps.Count == 0)
                viewModel.LoadLaps.Execute(null);
        }



        private void Driver_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenDriverDetail(this, viewModel?.Result?.Driver);
        }

        private void Constructor_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenConstructorDetail(this, viewModel?.Result?.Constructor);
        }
    }
}