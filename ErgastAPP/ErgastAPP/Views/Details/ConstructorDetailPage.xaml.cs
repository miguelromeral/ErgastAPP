using ErgastAPP.Models;
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
	public partial class ConstructorDetailPage : ContentPage
    {
        ConstructorDetailViewModel viewModel;

        public ConstructorDetailPage(ConstructorDetailViewModel constructorDetailViewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = constructorDetailViewModel;
        }
        

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            viewModel.LoadItemsCommand.Execute(null);
        }
    }
}