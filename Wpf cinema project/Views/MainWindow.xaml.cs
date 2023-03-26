using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_cinema_project.Commands;
using Wpf_cinema_project.ViewModels;
using Wpf_cinema_project.Views.UserControls;

namespace Wpf_cinema_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            App.MyGrid = myGrid;

            var movieCellViewModel = new MovieCellViewModel();
            var homeUc=new HomeUC();
            App.MyWrapPanel = homeUc.myPanel;
            vm = new MainViewModel(App.MyWrapPanel);
            homeUc.DataContext = movieCellViewModel;

            App.MyGrid.Children.Add(homeUc);

            this.DataContext = vm;

        }
    }
}
