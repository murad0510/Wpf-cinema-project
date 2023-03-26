using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf_cinema_project.Models;

namespace Wpf_cinema_project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static WrapPanel MyWrapPanel { get; set; }
        public static Grid MyGrid { get; set; }
        public static List<Movie> Movies { get; set; }
        public static UIElement BackPage { get; set; }
        public static List<string> CinemaLocations { get; set; }
    }
}
