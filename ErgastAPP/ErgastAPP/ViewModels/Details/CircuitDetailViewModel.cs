using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ErgastAPP.Models;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ErgastAPP.ViewModels
{
    public class CircuitDetailViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        private Circuit _circuit;
        public Circuit Circuit { get { return _circuit; } set { SetProperty(ref _circuit, value); } }


        public CircuitDetailViewModel(Circuit circuit)
        {
            Circuit = circuit;
            Title = Circuit.Name;

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
