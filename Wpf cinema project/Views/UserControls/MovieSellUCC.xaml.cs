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
using Wpf_cinema_project.ViewModels;

namespace Wpf_cinema_project.Views.UserControls
{
    /// <summary>
    /// Interaction logic for MovieSellUCC.xaml
    /// </summary>
    public partial class MovieSellUCC : UserControl
    {
        public MovieSellUCC(MovieCellViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
