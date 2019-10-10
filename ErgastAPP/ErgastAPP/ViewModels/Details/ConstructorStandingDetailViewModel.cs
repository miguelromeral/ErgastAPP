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
    public class ConstructorStandingDetailViewModel : BaseViewModel
    {
        public ObservableCollection<ConstructorStandings> Items { get; set; }

        public Command LoadItemsCommand { get; set; }

        public Race Race;

        private StandingsTable _standings;
        public StandingsTable Standings { get { return _standings; } set { SetProperty(ref _standings, value); } }

        public int Year;

        public ConstructorStandingDetailViewModel(Race r, int year)
        {
            Race = r;
            Year = year;

            Items = new ObservableCollection<ConstructorStandings>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Standings = await App.RestService.ConstructorStandingsByRace(Year, Race.Round);

                Items.Clear();
                foreach (var r in Standings.Standings[0].ConstructorStandings.OrderBy(x => x.Position).ThenBy(x => x.Wins))
                {
                    Items.Add(r);
                }
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
    }
}