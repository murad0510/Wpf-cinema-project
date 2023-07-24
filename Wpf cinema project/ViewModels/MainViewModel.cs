using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private string searchMovie;

        public string SearchMovie
        {
            get { return searchMovie; }
            set { searchMovie = value; OnPropertyChanged(); }
        }

        private ObservableCollection<PageNo> allPages;

        public ObservableCollection<PageNo> AllPages
        {
            get { return allPages; }
            set { allPages = value; OnPropertyChanged(); }
        }

        private PageNo selectedPageNo;

        public PageNo SelectedPageNo
        {
            get { return selectedPageNo; }
            set { selectedPageNo = value; OnPropertyChanged(); }
        }


        public RelayCommand SelectPageCommand { get; set; }
        public RelayCommand SearchButtonCommand { get; set; }

        static List<string> list = new List<string>
        {
            //"Black Adam",
            //"The Batman",
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
        public MainViewModel(WrapPanel myPanel)
        {

            SelectPageCommand = new RelayCommand((_) =>
            {
                var no = SelectedPageNo.No;
                //MyPanel.Children.Clear();
            });

            SearchButtonCommand = new RelayCommand(async (_) =>
            {
                bool s = false;
                //list.Clear();
                //list.Add(SearchMovie);
                MyPanel = myPanel;
                int left = 70;
                int up = 10;
                int right = 0;
                int down = 70;
                List<Movie> movies1 = new List<Movie>();

                //foreach (var item in list)
                //{
                var movies = await MovieService.GetMovie(SearchMovie);
                AllPages = new ObservableCollection<PageNo>();
                var pageSize = 2;
                var page = decimal.Parse(movies.Count().ToString()) / pageSize;
                var count = Math.Ceiling(page);
                for (int i = 0; i < count; i++)
                {
                    AllPages.Add(new PageNo
                    {
                        No = i + 1
                    });
                }

                //AllPages = new ObservableCollection<PageNo>(movies.Skip(0).Take(pageSize));

                foreach (var m in movies)
                {
                    var ucVM = new MovieCellViewModel()
                    {
                        Movie = m,
                    };
                    var uc = new MovieCellUC(ucVM);
                    uc.Margin = new System.Windows.Thickness(left, up, right, down);
                    if (!s)
                    {
                        MyPanel.Children.Clear();
                        s = true;
                    }

                    MyPanel.Children.Add(uc);

                    movies1.Add(m);
                }

                //}
                //if (App.Movies != null)
                //{
                //    App.Movies.Clear();
                //    App.MyWrapPanel.Children.Clear();

                //    App.Movies = movies1;
                //}
                //else
                //{
                //    App.Movies = movies1;
                //}




                FileHelper.WriteMovie(movies1);
            });
        }
    }
}
