using System.Data;
using System.Linq.Expressions;
using Business.Abstract;
using Business.Utilities;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace Business.Concrete;

public class MovieManager:IMovieService
{
    private IMovieDal _movieDal;
    public MovieManager(IMovieDal movieDal)
    {
        _movieDal = movieDal;
    }
    
    public IResult UpdateGenre(int movieId, string genreName, string genreId)
    {
        Movie movie = _movieDal.Get(x => x.id == movieId);
        string template = "[{'id': "+ genreId+",'name': '"+genreName+"'}]";
        movie.genres = template;
        Update(movie);
        return new Result(true, "Kategori Güncellendi");
    }


    public IResult AddGenreToMovie(int movieId, string genreName,string genreId)
    { 
        Movie movie =  _movieDal.Get(x => x.id == movieId);
        int index = movie.genres.Length - 1;
        string template = ",{'id': "+ genreId+",'name': '"+genreName+"'}";
        movie.genres = movie.genres.Insert(index, template);
        Update(movie);
        return new Result(true, "Filme Kategori Eklendi");
    }

    public IDataResult<List<Movie>> GetMovieList()
    {
        return new SuccessDataResult<List<Movie>>(_movieDal.GetList());

    }

    public IResult Add(Movie movie)
    {
        _movieDal.Add(movie);
        return new Result(true, "Film Eklendi");
    }

    public IResult Delete(Movie movie)
    {
        _movieDal.Delete(movie);
        return new Result(true, "Film Silindi");
    }

    public IResult Update(Movie movie)
    {
        _movieDal.Update(movie);
        return new Result(true,"Film Güncellendi");
    }
    

    public IDataResult<List<Movie>> GetMovieByRelaseDate()
    {

        return new SuccessDataResult<List<Movie>>(_movieDal.GetList().OrderByDescending(x => x.release_date).ToList());
    }

    public IDataResult<MovieDto> GetMovieDetail(int movieId)
    {
       var result = _movieDal.Get(x => x.id == movieId);
       result.Views_Count = result.Views_Count+1;
       _movieDal.Update(result);
        MovieDto movieDto = new MovieDto();
        movieDto.Overview = result.overview;
        movieDto.RelaseDate = result.release_date;
        movieDto.adult = result.adult;
        movieDto.homepage = result.homepage;
        movieDto.vote_avarage = result.vote_average;
        movieDto.revenue = result.revenue;
        movieDto.original_title = result.original_title;
        movieDto.Budget = result.budget;
        movieDto.tagline = result.tagline;
        movieDto.status = result.status;
        return new SuccessDataResult<MovieDto>(movieDto);
    }
    
    public IDataResult<List<Movie>> GetMovieListByGenre(string genreId)
    {
        
        var result = _movieDal.GetList(x => x.genres.Trim('[', ']').Contains(genreId));
        return new SuccessDataResult<List<Movie>>(result);

        
    }

    public IDataResult<List<Movie>> ListMostViewedMovies()
    {
       return new SuccessDataResult<List<Movie>>(_movieDal.GetList().OrderByDescending(x => x.Views_Count).ToList());
    }

    public IDataResult<List<Movie>> ListTopRatedMovies()
    {
        return new SuccessDataResult<List<Movie>>(_movieDal.GetList().OrderByDescending(x => x.vote_count).ToList());
    }
    
}
