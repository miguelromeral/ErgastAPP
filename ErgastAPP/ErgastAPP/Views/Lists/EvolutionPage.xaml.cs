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
	public partial class EvolutionPage : ContentPage
	{
        EvolutionViewModel viewModel;

		public EvolutionPage (EvolutionViewModel viewModel)
		{
			InitializeComponent ();

            BindingContext = this.viewModel = viewModel;
		}


        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.Slider = slider;

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (viewModel.Race?.Laps != null)
            {
                int num = (int)Math.Round(e.NewValue);
                slider.Value = num;
                num++;
                viewModel.UpdateTable(num);
            }
        }

        private void ChangeLap_Clicked(object sender, EventArgs e)
        {

            if (viewModel.Race?.Laps != null)
            {
                switch ((sender as Button).CommandParameter.ToString())
                {
                    case "-1":
                        slider.Value = slider.Value - 1;
                        break;
                    case "+1":
                    default:
                        slider.Value = slider.Value + 1;
                        break;
                }
            }
            else
            {
                Navigator.ShowWarning(this, true);
            }
        }
    }
}