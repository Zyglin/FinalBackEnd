using AutoMapper;
using DataAccess.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilms.DataAccess.Entity;
using WebFilms.ViewModel;

namespace WebFilms.Mapper
{
    public class ViewModelToData:Profile
    {
        public ViewModelToData()
        {
            CreateMap<CommentViewModel, Comment>();
            CreateMap<RatingViewModel, Rating>();

        }
    }
}
