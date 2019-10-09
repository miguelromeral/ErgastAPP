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
        

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.linkedin.com/in/miguelromeral/"));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://ergast.com/mrd/"));
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://dotnet.microsoft.com/apps/xamarin"));
        }
    }
}