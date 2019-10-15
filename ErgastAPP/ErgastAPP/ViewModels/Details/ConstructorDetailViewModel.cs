using ErgastAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ErgastAPP.ViewModels
{
    public class ConstructorDetailViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        Constructor constructor;
        public Constructor Constructor { get { return constructor; } set { SetProperty(ref constructor, value); } }

        Constructor dataoriginal;

        public string ConstructorId;


        RaceTable races;
        public RaceTable Races { get { return races; } set { SetProperty(ref races, value); } }

        SeasonTable seasonsWorldChampion;
        public SeasonTable SeasonsWorldChampions { get { return seasonsWorldChampion; } set { SetProperty(ref seasonsWorldChampion, value); } }

        DriverTable drivers;
        public DriverTable Drivers { get { return drivers; } set { SetProperty(ref drivers, value); } }

        RaceTable fastestLaps;
        public RaceTable FastestLaps { get { return fastestLaps; } set { SetProperty(ref fastestLaps, value); } }



        enum DataSource
        {
            Id,
            Provided
        }
        DataSource _source;

        public ConstructorDetailViewModel(string constructor)
        {
            ConstructorId = constructor;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _source = DataSource.Id;
        }

        public ConstructorDetailViewModel(Constructor c)
        {
            dataoriginal = c;
            Title = c.Name;
            ConstructorId = c.Id;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _source = DataSource.Provided;
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Constructor = null;
                switch (_source)
                {
                    case DataSource.Id:
                        dataoriginal = await App.RestService.GetConstructorAsync(ConstructorId);
                        Title = dataoriginal.Name;
                        break;
                    case DataSource.Provided:
                    default:
                        break;
                }
                Constructor = dataoriginal;
                FastestLaps = await App.RestService.FastestLapsByConstructorAsync(ConstructorId);
                SeasonsWorldChampions = await App.RestService.GetSeasonsConstructorsWorldChampionAsync(ConstructorId);
                Races = await App.RestService.GetRacesByConstructorAsync(ConstructorId);
                Drivers = await App.RestService.DriversByConstructorAsync(ConstructorId);
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
