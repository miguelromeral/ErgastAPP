using ErgastAPP.Models;
using ErgastAPP.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ErgastAPP.ViewModels
{
    public class ResultDetailViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        private Race _race;
        public Race Race { get { return _race; } set { SetProperty(ref _race, value); } }

        private int year;

        public ResultsDetailPage Page { get; set; }

        public ResultDetailViewModel(Race r, int year)
        {
            Race = r;
            this.year = year;
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Title = year + " " + Race.Name;
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
