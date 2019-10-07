using DataAccess.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebFilms.DataAccess.Entity
{
    public class User
    {
        [MaxLength(85)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(85)]
        public string Email { get; set; }

        [Required]
        [MaxLength(85)]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(85)]
        public string PasswordHash { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
