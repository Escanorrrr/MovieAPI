using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Context;
using DataAccess.Redis;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;
        private readonly IRedisHelper _redisHelper;

        public MovieController(IMovieService movieService, IRedisHelper redisHelper)
        {
            _movieService = movieService;
            _redisHelper = redisHelper;
        }
        [HttpPut( "updateMovie")]
        public IActionResult UpdateMovie(Movie movie)
        {
            var result = _movieService.Update(movie);

            return Ok(result);
        }
        [HttpPost( "addMovie")]
        public IActionResult AddMovie(Movie movie)
        {
            var result = _movieService.Add(movie);

            return Ok(result);
        }
        [HttpDelete( "deleteMovie")]
        public IActionResult DeleteMovie(Movie movie)
        {
            var result = _movieService.Delete(movie);

            return Ok(result);
        }
        
        [HttpGet( "getList")]
        public IActionResult GetList()
        {
            var result = _movieService.GetMovieList();

            return Ok(result);
        }
        
        [HttpGet("getListByRelaseDate")]
        public IActionResult GetListByRelaseDate()
        {
            var result = _movieService.GetMovieByRelaseDate();
            return Ok(result);
        }
        
        [HttpGet("getMovieDetails")]
        public IActionResult GetMovieDetails(int movieId)
        {
            var result = _movieService.GetMovieDetail(movieId);
            return Ok(result);
        }
        [HttpGet("getMovieByGenre")]
        public IActionResult GetMovieByGenre(string genreId)
        {
            var result = _movieService.GetMovieListByGenre(genreId);
            return Ok(result);
        }
        [HttpGet("getMovieByRate")]
        public IActionResult GetListByTopRated()
        {
            var result = _movieService.ListTopRatedMovies();
            return Ok(result);
        }
        [HttpPost("addGenre")]
        public IActionResult AddGenreToMovie(int movieId, string genreName,string genreId)
        {
            _movieService.AddGenreToMovie(movieId,genreName,genreId);
            return Ok();
        }
        [HttpPut("UpdateGenre")]
        public IActionResult UpdateGenre(int movieId, string genreName,string genreId)
        {
            _movieService.UpdateGenre(movieId,genreId,genreName);
            return Ok();
        }

    }
}
