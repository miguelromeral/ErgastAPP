using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ErgastAPP.Views;
using ErgastAPP.Services;
using ErgastAPP.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ErgastAPP
{
    public partial class App : Application
    {
        public static RestService RestService;
        public static ErgastAPI API;

        public App()
        {
            InitializeComponent();

            RestService = new RestService();
            API = new ErgastAPI();

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
