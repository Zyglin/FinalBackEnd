using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebFilms.ViewModel
{
    public class UserViewModel
    {
        [Required]
        [MaxLength(85)]
        public string Email { get; set; }

        [Required]
        public string Filebase64 { get; set; }

    }
}
