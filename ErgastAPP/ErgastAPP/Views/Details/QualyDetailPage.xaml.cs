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
	public partial class QualyDetailPage : ContentPage
	{
        QualyDetailViewModel viewModel;

		public QualyDetailPage (QualyDetailViewModel viewModel)
        {
            InitializeComponent();
            
            BindingContext = this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Title = viewModel.Year + " " + viewModel.Race.Name;

            if (viewModel.Items != null)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
        }
    }
}