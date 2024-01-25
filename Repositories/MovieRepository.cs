using FilmWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmWebApi.Repositories;

public class MovieRepository
{
    private readonly ApplicationContext _context;

    public MovieRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetMovies()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task<Movie> GetMovie(Guid id)
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

    public async Task<IActionResult> DeleteMovie(Guid id)
    {
        var movieToDelete = await _context.Movies.FindAsync(id);

        if (movieToDelete != null)
        {
            _context.Movies.Remove(movieToDelete);
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        return new NotFoundResult();
    }

    public async Task<Movie> UpdateMovie(Movie movie)
    {
        _context.Entry(movie).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return movie;
    }
}
