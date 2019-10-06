using ErgastAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace ErgastAPP.ViewModels
{
    public class ConstructorViewModel : BaseViewModel
    {
        public ObservableCollection<Constructor> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        DataErgastConstructors Data;

        public ConstructorViewModel()
        {
            Title = "Constructors";
            Items = new ObservableCollection<Constructor>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Data = await App.RestService.GetConstructorsAsync();
                Data.ConstructorTable.Constructors = Data.ConstructorTable.Constructors.OrderBy(o => o.Name).ToList();
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
            foreach (var item in Data.ConstructorTable.Constructors.Where(i => i.Name.ToLower().Contains(content.ToLower())))
            {
                Items.Add(item);
            }
        }

    }
}
