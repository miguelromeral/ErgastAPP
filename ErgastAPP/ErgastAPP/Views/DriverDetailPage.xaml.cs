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
	public partial class DriverDetailPage : ContentPage
	{
        DriverDetailViewModel viewModel;

		public DriverDetailPage (DriverDetailViewModel viewModel)
		{
			InitializeComponent ();
            
            BindingContext = this.viewModel = viewModel;
        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Item == null)
                viewModel.LoadItemsCommand.Execute(null);
            //viewModel.Item = new Models.Driver()
            //{
            //    GivenName = "Miguel",
            //    FamilyName = "Romeral",
            //    Nationality = "Spanish"
            //};
        }
    }
}