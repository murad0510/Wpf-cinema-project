using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf_cinema_project.Commands;
using Wpf_cinema_project.Helpers;
using Wpf_cinema_project.Models;
using Wpf_cinema_project.Services;
using Wpf_cinema_project.Views;
using Wpf_cinema_project.Views.UserControls;

namespace Wpf_cinema_project.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public WrapPanel MyPanel { get; set; }
        public bool StartMain { get; set; }

        public MainViewModel(WrapPanel myPanel)
        {
            MyPanel = myPanel;
            List<string> list = new List<string>
            {
                "Black Adam",
                "The Batman",
                //"Xoxan",
                //"Hayaller Ülkesi",
                //"Troll",
                //"Halloween Ends",
                //"Morbius",
                //"Interstellar",
                //"Mulan",
                //"Dune",
                //"Tenet",
                //"Black Panther",
                //"The Shawshank Redemption",
                //"The Godfather",
                //"Avatar",
                //"Logan",
                //"The Avengers",
                //"Captain America: The Winter Soldier",
                //"Wonder Woman",
                //"Aquaman",
                //"1917",
                //"Doctor Strange",
                //"Deadpool",
                //"John Wick",
                //"Sicario",
                //"Gladiator",
            };
            int left = 70;
            int up = 10;
            int right = 0;
            int down = 70;
            List<Movie> movies1 = new List<Movie>();

            foreach (var item in list)
            {
                var movies = MovieService.GetMoviee(item);
                foreach (var m in movies)
                {
                    var ucVM = new MovieCellViewModel
                    {
                        Movie = m,
                    };
                    var uc = new MovieCellUC(ucVM);
                    uc.Margin = new System.Windows.Thickness(left, up, right, down);

                    MyPanel.Children.Add(uc);

                    movies1.Add(m);
                }
            }
            App.Movies = movies1;

            FileHelper.WriteMovie(movies1);
        }
    }
}
