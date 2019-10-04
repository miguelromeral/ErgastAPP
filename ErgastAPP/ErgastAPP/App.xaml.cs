using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ErgastAPP.Views;
using ErgastAPP.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ErgastAPP
{
    public partial class App : Application
    {
        public static RestService RestService;

        public App()
        {
            InitializeComponent();

            RestService = new RestService();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
