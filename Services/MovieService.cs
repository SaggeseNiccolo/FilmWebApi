using FilmWebApi.Entities;
using FilmWebApi.Repositories;

namespace FilmWebApi.Services;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetMovies();
    Task<Movie> GetMovie(Guid id);
    Task<Movie> AddMovie(Movie movie);
    Task DeleteMovie(Guid id);
    Task<Movie> UpdateMovie(Movie movie);
}

public class MovieService : IMovieService
{
    private readonly MovieRepository _movieRepository;

    public MovieService(MovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<IEnumerable<Movie>> GetMovies()
    {
        return await _movieRepository.GetMovies();
    }

    public async Task<Movie> GetMovie(Guid id)
    {
        return await _movieRepository.GetMovie(id);
    }

    public async Task<Movie> AddMovie(Movie movie)
    {
        return await _movieRepository.AddMovie(movie);
    }

    public async Task DeleteMovie(Guid id)
    {
        await _movieRepository.DeleteMovie(id);
    }

    public async Task<Movie> UpdateMovie(Movie movie)
    {
        return await _movieRepository.UpdateMovie(movie);
    }
}
