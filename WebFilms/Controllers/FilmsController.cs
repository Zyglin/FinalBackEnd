﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebFilms.DataAccess.Entity;
using WebFilms.Services.Interface;
using WebFilms.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebFilms.Controllers
{
    [Route("api/[controller]")]
    public class FilmsController : Controller
    {
        private IFilmService _filmService;
        private readonly IMapper _mapper;
        public FilmsController(IFilmService filmService, IMapper mapper)
        {
            _filmService = filmService;
            _mapper = mapper;
        }
     
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var model = new ListFilmsViewModel();
            List<Film> films = _filmService.GetAllFilms().ToList();
            model.Films = _mapper.Map<List<Film>,List<FilmViewModel>>(films);
            return Ok(model.Films);       
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(Guid id)
        {
            var model = new FilmViewModel();
            Film film = _filmService.GetFilm(id);
            model = _mapper.Map <Film , FilmViewModel > (film);

            return Ok(model);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
           
        }
    }
}