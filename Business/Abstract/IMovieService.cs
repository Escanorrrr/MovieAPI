using Business.Utilities;
using Entity;
using Entity.DTOs;

namespace Business.Abstract;

public interface IMovieService
{
    IResult UpdateGenre(int movieId, string genreName, string genreId);
    IResult AddGenreToMovie(int movieId, string genreName,string genreId);
    IDataResult<List<Movie>> GetMovieList();
    IResult Add(Movie movie);
    IResult Delete(Movie movie);
    IResult Update(Movie movie);
    IDataResult<List<Movie>> GetMovieByRelaseDate();
    IDataResult<MovieDto> GetMovieDetail(int movieId);
    IDataResult<List<Movie>> GetMovieListByGenre(string genreId);
    IDataResult<List<Movie>> ListMostViewedMovies();
    IDataResult<List<Movie>> ListTopRatedMovies();

}