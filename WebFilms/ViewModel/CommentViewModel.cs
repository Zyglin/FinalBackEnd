using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebFilms.DataAccess.Entity;

namespace WebFilms.ViewModel
{
    public class CommentViewModel
    {
        [Required]
        [MaxLength(160)]
        public string Description { get; set; }
        public Guid FilmId { get; set; }

        public UserViewModel User { get; set; }
        public Guid UserId { get; set; }
    }
}
