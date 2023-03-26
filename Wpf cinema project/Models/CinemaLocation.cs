using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_cinema_project.Models
{
    public class CinemaLocation
    {
        public string PlaceCinemas { get; set; }

        public override string ToString()
        {
            return $"{PlaceCinemas}";
        }

        public static implicit operator string(CinemaLocation v)
        {
            throw new NotImplementedException();
        }
    }
}
