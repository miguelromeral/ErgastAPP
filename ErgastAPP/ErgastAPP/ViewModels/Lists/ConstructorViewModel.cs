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

        ConstructorTable Data;

        public ConstructorViewModel()
        {
            Title = "Constructors";
            Items = new ObservableCollection<Constructor>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public ConstructorViewModel(ConstructorTable data, string title)
        {
            this.Data = data;
            Title = title;
            Items = new ObservableCollection<Constructor>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommandConstructor());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Data = await App.RestService.GetConstructorsAsync();
                Data.Constructors = Data.Constructors.OrderBy(o => o.Name).ToList();
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

        async Task ExecuteLoadItemsCommandConstructor()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Data.Constructors = Data.Constructors.OrderBy(o => o.Name).ToList();
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
            foreach (var item in Data.Constructors.Where(i => i.Name.ToLower().Contains(content.ToLower())))
            {
                Items.Add(item);
            }
        }

    }
}
