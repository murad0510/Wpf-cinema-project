using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Media3D;
using Wpf_cinema_project.Commands;
using Wpf_cinema_project.Helpers;
using Wpf_cinema_project.Models;
using Wpf_cinema_project.Repostory;
using Wpf_cinema_project.Services;
using Wpf_cinema_project.Views.UserControls;

namespace Wpf_cinema_project.ViewModels
{
    public class MovieCellViewModel : BaseViewModel
    {
        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }

        private string selectedItem;

        public string SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; OnPropertyChanged(); }
        }

        private string selectedItemLanguage;

        public string SelectedItemLanguage
        {
            get { return selectedItemLanguage; }
            set { selectedItemLanguage = value; OnPropertyChanged(); }
        }

        private List<Movie> allMovies;

        public List<Movie> AllMovies
        {
            get { return allMovies; }
            set { allMovies = value; OnPropertyChanged(); }
        }



        public List<Movie> Movies { get; set; }


        public RelayCommand BaseButton { get; set; }
        public RelayCommand SimpleButton { get; set; }
        public RelayCommand SelectionChang { get; set; }
        public RelayCommand SelectionChangeLanguage { get; set; }


        private List<string> cinemaLocations;

        public List<string> CinemaLocations
        {
            get { return cinemaLocations; }
            set { cinemaLocations = value; OnPropertyChanged(); }
        }

        private List<string> cinemaLanguageItemSource;

        public List<string> CinemaLanguageItemSource
        {
            get { return cinemaLanguageItemSource; }
            set { cinemaLanguageItemSource = value; OnPropertyChanged(); }
        }


        public MovieCellViewModel()
        {
            AllMovies = App.MovieRepo.Movies;
            CinemaLocations = new List<string>
            {
                "Cinema",
                "28 Mall",
                "Deniz Mall",
                //"Azerbaijan Cinema",
                //"Amburan Mall",
                //"Deniz Mall",
                //"Sumgayit",
                //"Khamsa Park",
                //"Ganja Mall",
                //"Nakhchivan",
                //"Shamakhy",
            };

            CinemaLanguageItemSource = new List<string>
            {
                "English",
                "Azerbaijani",
                "Turkish",
            };


            BaseButton = new RelayCommand((obj) =>
            {
                MessageBox.Show("sas");
            });

            SimpleButton = new RelayCommand((obj) =>
            {
                MessageBox.Show("safdsfsas");
            });

            SelectionChang = new RelayCommand((_) =>
            {
                int left = 70;
                int up = 10;
                int right = 0;
                int down = 70;

                App.MyGrid.Children.RemoveAt(0);
                App.MyWrapPanel.Children.RemoveAt(0);

                for (int i = 0; i < FileHelper.ReadMovie().Count; i++)
                {
                    var homeUc = new HomeUC();
                    var movieRepostory = new MovieRepostory();
                    if (FileHelper.ReadMovie()[i].CinemaLocation == SelectedItem)
                    {
                        var ucVM = new MovieCellViewModel
                        {
                            Movie = App.Movies[i],
                        };

                        App.MyWrapPanel = homeUc.myPanel;

                        var uc = new MovieCellUC(ucVM);
                        uc.Margin = new System.Windows.Thickness(left, up, right, down);
                        App.MyWrapPanel.Children.Add(uc);
                        App.MyGrid.Children.Add(homeUc);
                    }
                    else if (SelectedItem == "Cinema")
                    {
                        List<Movie> movies = new List<Movie>();
                        for (int k = 0; k < FileHelper.ReadMovie().Count; k++)
                        {
                            var ucVM = new MovieCellViewModel
                            {
                                Movie = App.Movies[k],
                            };

                            App.MyWrapPanel = homeUc.myPanel;
                            var uc = new MovieCellUC(ucVM);
                            uc.Margin = new System.Windows.Thickness(left, up, right, down);

                            App.MyWrapPanel.Children.Add(uc);
                            App.MyGrid.Children.Add(homeUc);
                        }
                    }
                }
            });

            SelectionChangeLanguage = new RelayCommand((obj) =>
            {
                App.MyGrid.Children.RemoveAt(0);

                var homeUc = new HomeUC();
                App.MyWrapPanel = homeUc.myPanel;
                for (int i = 0; i < FileHelper.ReadMovie().Count; i++)
                {
                    if (App.Movies[i].Language.Contains(SelectedItemLanguage))
                    {
                        MessageBox.Show($"{FileHelper.ReadMovie()[i].Name}");
                    }
                }
            });
        }
    }
}
