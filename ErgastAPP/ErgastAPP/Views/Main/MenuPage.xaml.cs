using ErgastAPP.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ErgastAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Home, Title="Home",
                    Image = "https://raw.githubusercontent.com/miguelromeral/ErgastAPP/master/ErgastAPP/ErgastAPP/Resources/Icons/house_white.png"},
                new HomeMenuItem {Id = MenuItemType.Seasons, Title="Seasons",
                    Image = "https://raw.githubusercontent.com/miguelromeral/ErgastAPP/master/ErgastAPP/ErgastAPP/Resources/Icons/season_white.png" },
                new HomeMenuItem {Id = MenuItemType.Races, Title="Races",
                    Image = "https://raw.githubusercontent.com/miguelromeral/ErgastAPP/master/ErgastAPP/ErgastAPP/Resources/Icons/trophy_white.png" },
                new HomeMenuItem {Id = MenuItemType.Circuits, Title="Circuits",
                    Image = "https://raw.githubusercontent.com/miguelromeral/ErgastAPP/master/ErgastAPP/ErgastAPP/Resources/Icons/circuit_white.png" },
                new HomeMenuItem {Id = MenuItemType.Drivers, Title="Drivers",
                    Image = "https://raw.githubusercontent.com/miguelromeral/ErgastAPP/master/ErgastAPP/ErgastAPP/Resources/Icons/driver_white.png" },
                new HomeMenuItem {Id = MenuItemType.Constructors, Title="Constructors",
                    Image = "https://raw.githubusercontent.com/miguelromeral/ErgastAPP/master/ErgastAPP/ErgastAPP/Resources/Icons/constructor_white.png" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About",
                    Image = "https://raw.githubusercontent.com/miguelromeral/ErgastAPP/master/ErgastAPP/ErgastAPP/Resources/Icons/about_white.png" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}