using System;
using System.Collections.Generic;
using System.Text;
using WebFilms.DataAccess.Entity;

namespace DataAccess.DataAccess.Entity
{
    public class Rating
    {
        public Guid Id { get; set; }
        
        public int Value { get; set; }
        public Film Film { get; set; }
        public Guid FilmId { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

    }
}
