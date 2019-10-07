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
                new HomeMenuItem {Id = MenuItemType.Home, Title="Home", Image = ""},
                new HomeMenuItem {Id = MenuItemType.Seasons, Title="Seasons", Image = "" },
                new HomeMenuItem {Id = MenuItemType.Circuits, Title="Circuits", Image = "" },
                new HomeMenuItem {Id = MenuItemType.Drivers, Title="Drivers", Image = "" },
                new HomeMenuItem {Id = MenuItemType.Constructors, Title="Constructors", Image = "" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About", Image = "" }
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