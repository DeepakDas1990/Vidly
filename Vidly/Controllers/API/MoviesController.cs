using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET API/Movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies
                .Include(m=>m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDTO>));
        }

        //GET API/Movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        //POST API/Movies/1
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movieDTO.Id), movieDTO);
        }

        //PUT API/Movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int Id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return NotFound();

            Mapper.Map(movieDTO, movie);
            _context.SaveChanges();

            return Ok();
        }

        //DELETE API/Movies/1
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }
    }
}
