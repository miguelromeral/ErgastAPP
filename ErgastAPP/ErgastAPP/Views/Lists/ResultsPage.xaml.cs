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
	public partial class ResultsPage : ContentPage
	{
        ResultViewModel viewModel;

        public ResultsPage(ResultViewModel viewModel)
        {
            InitializeComponent();

            //viewModel.Page = this;
            BindingContext = this.viewModel = viewModel;
		}


        protected override void OnAppearing()
        {
            base.OnAppearing();


            if (viewModel.Items != null)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
            
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Result;
            Navigator.OpenResultDetail(this, item, viewModel.Race, item?.Driver, false);
            ItemsListView.SelectedItem = null;
        }
    }
}