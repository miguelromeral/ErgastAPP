using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ErgastAPP.Views;
using ErgastAPP.Services;
using ErgastAPP.Models;
using ErgastAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
