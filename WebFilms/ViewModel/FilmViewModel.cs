using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebFilms.DataAccess.Entity;

namespace WebFilms.ViewModel
{
    public class FilmViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(85)]
        public string Name { get; set; }


        [MaxLength(85)]
        public string Description { get; set; }
        public string YoutubeId { get; set; }

        [Required]
        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        public string ImageXPath { get; set; }
    }
}
