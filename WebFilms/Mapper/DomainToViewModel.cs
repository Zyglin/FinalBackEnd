using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilms.DataAccess.Entity;
using WebFilms.ViewModel;

namespace WebFilms.Mapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Film, FilmViewModel>();
            CreateMap<Comment, CommentViewModel>();
            CreateMap<User, UserViewModel>();

        }
    }
}
