using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFilms.ViewModel
{
    public class RatingViewModel
    {
        public int Value { get; set; }
        public Guid FilmId { get; set; }
    }
}
