using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_cinema_project.Models;

namespace Wpf_cinema_project.Helpers
{
    public class FileHelper
    {
        public static void WriteMovie(List<Movie> movies)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter("Movies.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, movies);
                }
            }
        }

        public static List<Movie> ReadMovie()
        {
            List<Movie> movies = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader("Movies.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    movies = serializer.Deserialize<List<Movie>>(jr);
                }
            }
            return movies;
        }
    }
}
