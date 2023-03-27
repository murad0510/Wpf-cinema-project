using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_cinema_project.Helpers;
using Wpf_cinema_project.Models;

namespace Wpf_cinema_project.Repostory
{
    public class MovieRepostory
    {
        public List<Movie> Movies { get; set; }
        public MovieRepostory()
        {
            if (!File.Exists("movies.json"))
            {
                Movies = new List<Movie> {
            new Movie
            {
              Id=1,
              Name="Mulan",
              ImagePath="/Images/Kungfu Mulan Photo.jpg",
              Rating="7.6",
              Format="2D",
              Moviee="176 min",
            },
            new Movie
            {
              Id=2,
              Name="Mulan",
              ImagePath="/Images/Kungfu Mulan Photo.jpg",
              Rating="7.6",
              Format="2D",
              Moviee="176 min",
            },
            new Movie
            {
              Id=3,
              Name="Mulan",
              ImagePath="/Images/Kungfu Mulan Photo.jpg",
              Rating="7.6",
              Format="2D",
              Moviee="176 min",
            }
        };
                FileHelper.WriteMovie(Movies);
            }
            else
            {
                Movies = FileHelper.ReadMovie();
            }
        }

    }
}
