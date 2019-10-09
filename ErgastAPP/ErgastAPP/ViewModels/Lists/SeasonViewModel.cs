﻿using ErgastAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ErgastAPP.ViewModels
{
    public class SeasonViewModel : BaseViewModel
    {
        public ObservableCollection<Season> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        StandingsTable _standings;
        public StandingsTable Standings { get { return _standings; } set { SetProperty(ref _standings, value); } }

        DataErgastSeasons data;
        StandingsTable ds;
        StandingsTable cs;

        public SeasonViewModel()
        {
            Title = "Seasons";
            Items = new ObservableCollection<Season>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                data = await App.RestService.GetSeasonsDataAsync();
                ds = await App.RestService.DriverStandingsBySeason();
                cs = await App.RestService.ConstructorStandingsBySeason();

                foreach (var item in data.SeasonTable.Seasons)
                {
                    item.DriverChampion = ds.Standings.Where(x => x.Season == item.Year).Select(x => x.DriverStandings[0].Driver).FirstOrDefault();
                    item.DriverConstructorChampion = ds.Standings.Where(x => x.Season == item.Year).Select(x => x.DriverConstructorChampion).FirstOrDefault();
                    item.ConstructorChampion = cs.Standings.Where(x => x.Season == item.Year).Select(x => x.ConstructorChampion).FirstOrDefault();
                    
                }

                LoadItemsFromData();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void LoadItemsFromData(string content = "")
        {
            Items.Clear();
            foreach (var item in data.SeasonTable.Seasons.Where(x => x.Year.ToString().Contains(content)))
            {
                Items.Add(item);
            }
        }
    }
}
