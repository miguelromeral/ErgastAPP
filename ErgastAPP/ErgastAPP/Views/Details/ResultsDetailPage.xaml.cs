using ErgastAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ErgastAPP.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultsDetailPage : ContentPage
	{
        ResultDetailViewModel viewModel;

        public ResultsDetailPage(ResultDetailViewModel viewModel)
        {
            InitializeComponent();

            //viewModel.Page = this;
            BindingContext = this.viewModel = viewModel;
		}


        protected override void OnAppearing()
        {
            base.OnAppearing();

            Title = viewModel.Year + " " + viewModel.Race.Name;

            if (viewModel.Items != null)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }

            //LoadGUI();
        }

        //void LoadGUI()
        //{
        //    table.Children.Clear();

        //    grid = new Grid();
        //    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

        //    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

        //    foreach (var c in viewModel.Race.Results)
        //    {
        //        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        //    }
            
        //    grid.Children.Add(new Label { Text = "Pos.", Style = (Style)Application.Current.Resources["HeaderResult"] }, 0, 0);
        //    grid.Children.Add(new Label { Text = "No.", Style = (Style)Application.Current.Resources["HeaderResult"] }, 1, 0);
        //    grid.Children.Add(new Label { Text = "Driver", Style = (Style)Application.Current.Resources["HeaderResult"] }, 2, 0);
        //    grid.Children.Add(new Label { Text = "Constructor", Style = (Style)Application.Current.Resources["HeaderResult"] }, 3, 0);
        //    grid.Children.Add(new Label { Text = "Laps", Style = (Style)Application.Current.Resources["HeaderResult"] }, 4, 0);
        //    grid.Children.Add(new Label { Text = "Time/Retired", Style = (Style)Application.Current.Resources["HeaderResult"] }, 5, 0);
        //    grid.Children.Add(new Label { Text = "Grid", Style = (Style)Application.Current.Resources["HeaderResult"] }, 6, 0);
        //    grid.Children.Add(new Label { Text = "Points", Style = (Style)Application.Current.Resources["HeaderResult"] }, 7, 0);

        //    int row = 1;
        //    Style style = null;
        //    foreach(var r in viewModel.Race.Results.OrderBy(x => x.Position))
        //    {
        //        style = (row % 2 == 0 ? (Style) Application.Current.Resources["ListItemEven"] : (Style) Application.Current.Resources["ListItemOdd"]);

        //        grid.Children.Add(new Label { Text = r.PositionText }, 0, row);
        //        grid.Children.Add(new Label { Text = r.Driver.Number.ToString() }, 1, row);
        //        grid.Children.Add(new Label { Text = r.Driver.Fullname }, 2, row);
        //        grid.Children.Add(new Label { Text = r.Constructor.Name }, 3, row);
        //        grid.Children.Add(new Label { Text = r.Laps.ToString() }, 4, row);
        //        grid.Children.Add(new Label { Text = r.PrettyResult }, 5, row);
        //        grid.Children.Add(new Label { Text = r.Grid.ToString() }, 6, row);
        //        grid.Children.Add(new Label { Text = r.Points.ToString() }, 7, row);
        //        row++;
        //    }

        //    table.Children.Add(grid);
        //}
	}
}