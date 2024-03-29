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
    public class QualyViewModel : BaseViewModel
    {
        public ObservableCollection<Qualifying> Items { get; set; }

        public Command LoadItemsCommand { get; set; }

        private Race _race;
        public Race Race { get { return _race; } set { SetProperty(ref _race, value); } }

        public int Year;

        public QualyViewModel(Race r)
        {
            Race = r;
            Year = r.Season;

            Items = new ObservableCollection<Qualifying>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                
                var aux = await App.RestService.QualifyingByRaceAsync(Year, Race.Round);
                Race.Qualifying = aux.Qualifying;

                Title = Year + " " + Race.Name;

                Items.Clear();
                foreach (var r in Race.Qualifying.OrderBy(x => x.Position))
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
