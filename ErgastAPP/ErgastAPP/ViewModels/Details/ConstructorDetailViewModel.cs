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
        

        public string ConstructorId;


        public ConstructorDetailViewModel(Constructor c)
        {
            Constructor = c;
            Title = c.Name;

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
