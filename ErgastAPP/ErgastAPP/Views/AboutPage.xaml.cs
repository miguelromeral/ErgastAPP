using ErgastAPP.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ErgastAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            DataErgast weatherData = await App.RestService.GetSeasonsDataAsync("https://ergast.com/api/f1/seasons.json");
        }
    }
}