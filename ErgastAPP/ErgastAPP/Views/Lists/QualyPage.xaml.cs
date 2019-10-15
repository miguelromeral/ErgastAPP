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
	public partial class QualyPage : ContentPage
	{
        QualyViewModel viewModel;

		public QualyPage (QualyViewModel viewModel)
        {
            InitializeComponent();
            
            BindingContext = this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}