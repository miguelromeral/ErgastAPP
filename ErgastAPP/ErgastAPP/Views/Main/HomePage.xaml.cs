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
		public HomePage()
		{
			InitializeComponent();
		}
        
        private void LastRace_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenRaceDetailLast(this);
        }

        private void Driver_Clicked(object sender, EventArgs e)
        {
            Navigator.OpenDriverDetail(this, (sender as Button).CommandParameter.ToString());
        }
    }
}