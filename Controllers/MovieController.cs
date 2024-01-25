using FilmWebApi.Services;
using FilmWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FilmWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
// [Authorize]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<IEnumerable<Movie>> GetMovies()
    {
        return await _movieService.GetMovies();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovie(Guid id)
    {
        return await _movieService.GetMovie(id);
    }

    [HttpPost]
    public async Task<ActionResult<Movie>> AddMovie(Movie movie)
    {
        var newMovie = await _movieService.AddMovie(movie);
        return CreatedAtAction(nameof(GetMovie), new { id = newMovie.Id }, newMovie);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMovie(Guid id)
    {
        await _movieService.DeleteMovie(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Movie>> UpdateMovie(Guid id, Movie movie)
    {
        if (id != movie.Id)
        {
            return BadRequest();
        }

        return await _movieService.UpdateMovie(movie);
    }
}
