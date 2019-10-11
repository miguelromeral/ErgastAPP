using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ErgastAPP.Models;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ErgastAPP.ViewModels
{
    public class ResultDetailViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        private Result _result;
        public Result Result { get { return _result; } set { SetProperty(ref _result, value); } }


        public ResultDetailViewModel(Result r, string title)
        {
            Result = r;
            Title = title;

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
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
