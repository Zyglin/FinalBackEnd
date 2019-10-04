using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebFilms.DataAccess.Entity
{
    public class Comment
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(160)]
        public string Description { get; set; }

        public Film Film { get; set; }

        public Guid FilmId { get; set; }

        public User User { get; set; }

        public Guid UserId { get; set; }
    }
}
