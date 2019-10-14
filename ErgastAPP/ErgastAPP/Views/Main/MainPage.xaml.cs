using ErgastAPP.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ErgastAPP.ViewModels;

namespace ErgastAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Home, (NavigationPage) Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Home:
                        MenuPages.Add(id, new NavigationPage(new HomePage()));
                        break;

                    case (int)MenuItemType.Seasons:
                        MenuPages.Add(id, new NavigationPage(new SeasonsPage(new SeasonViewModel())));
                        break;

                    case (int)MenuItemType.Drivers:
                        MenuPages.Add(id, new NavigationPage(new DriversPage(new DriversViewModel())));
                        break;

                    case (int)MenuItemType.Races:
                        MenuPages.Add(id, new NavigationPage(new RacePage(new RaceViewModel())));
                        break;

                    case (int)MenuItemType.Circuits:
                        MenuPages.Add(id, new NavigationPage(new CircuitsPage(new CircuitViewModel())));
                        break;

                    case (int)MenuItemType.Constructors:
                        MenuPages.Add(id, new NavigationPage(new ConstructorPage(new ConstructorViewModel())));
                        break;

                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;

                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }


    }
}