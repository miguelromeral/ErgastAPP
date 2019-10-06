﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ErgastAPP.Models;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ErgastAPP.ViewModels
{
    public class RaceDetailViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        private Race _race;
        public Race Race { get { return _race; } set { SetProperty(ref _race, value); } }

        public int _year;
        public int _round;


        public RaceDetailViewModel(int year, int round)
        {
            _year = year;
            _round = round;

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var data = await App.RestService.GetRaceResultsAsync(_year, _round);

                Race = data.RaceTable.Races[0];
                Title = _year + " " + Race.Name;
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
