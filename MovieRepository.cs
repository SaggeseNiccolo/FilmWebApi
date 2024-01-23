using FilmWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmWebApi;

public class MovieRepository
{
    private readonly MovieContext _context;

    public MovieRepository(MovieContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetMovies()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task<Movie> GetMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id) ?? throw new Exception("Movie not found");
        
        return movie;
    }

    public async Task<Movie> AddMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
        return movie;
    }

    public async Task DeleteMovie(int id)
    {
        var movieToDelete = await _context.Movies.FindAsync(id);

        if (movieToDelete != null)
        {
            _context.Movies.Remove(movieToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
