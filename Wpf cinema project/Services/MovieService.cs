using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wpf_cinema_project.Helpers;
using Wpf_cinema_project.Models;
using Wpf_cinema_project.ViewModels;

namespace Wpf_cinema_project.Services
{
    public class MovieService
    {
        public static dynamic Data { get; set; }
        public static dynamic SingleData { get; set; }

        public static async Task<List<Movie>> GetMovie(string movie)
        {

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            response = await httpClient.GetAsync($@"http://www.omdbapi.com/?apikey=ab88e99a&s={movie}&plot=full");
            var str = await response.Content.ReadAsStringAsync();
            Data = JsonConvert.DeserializeObject(str);

            List<Movie> movies = new List<Movie>();
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    response = await httpClient.GetAsync($@"http://www.omdbapi.com/?apikey=ab88e99a&t={Data.Search[i].Title}&plot=full");
                    str = await response.Content.ReadAsStringAsync();
                    SingleData = JsonConvert.DeserializeObject(str);

                    var myMovie = new Movie
                    {
                        Description = SingleData.Plot,
                        ImagePath = SingleData.Poster,
                        Name = SingleData.Title,
                        Rating = SingleData.imdbRating,
                    };
                    movies.Add(myMovie);
                }
            }
            catch (Exception)
            {
            }
            return movies;

        }

        public static Task<List<Movie>> GetMoviee(string movie)
        {
            return Task.Run(async () =>
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = new HttpResponseMessage();
                response = httpClient.GetAsync($@"http://www.omdbapi.com/?apikey=ddee1dae&s={movie}&plot=full").Result;
                var str = await response.Content.ReadAsStringAsync();
                Data = JsonConvert.DeserializeObject(str);

                MovieCellViewModel movieCellView;

                movieCellView = new MovieCellViewModel();

                List<Movie> movies = new List<Movie>();
                try
                {
                    for (int i = 0; i < 1; i++)
                    {
                        response = httpClient.GetAsync($@"http://www.omdbapi.com/?apikey=ddee1dae&t={Data.Search[i].Title}&plot=full").Result;
                        str = await response.Content.ReadAsStringAsync();
                        SingleData = JsonConvert.DeserializeObject(str);


                        int rand = RandomNumber(0, movieCellView.CinemaLocations.Count);

                        var myMovie = new Movie
                        {
                            Description = SingleData.Plot,
                            ImagePath = SingleData.Poster,
                            Name = SingleData.Title,
                            Rating = SingleData.imdbRating,
                            Format = "2D",
                            Moviee = SingleData.Runtime,
                            Language = SingleData.Language,
                            CinemaLocation = movieCellView.CinemaLocations[1],
                        };
                        movies.Add(myMovie);
                    }
                }
                catch (Exception)
                {

                }
                return movies;
            });
        }
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}

