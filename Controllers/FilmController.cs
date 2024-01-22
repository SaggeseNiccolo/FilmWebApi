using FilmWebApi;
using FilmWebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace;

[Route("api/[controller]")]
[ApiController]
public class FilmController : ControllerBase
{
    private readonly MovieContext _context;

    public FilmController(MovieContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Movies);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Movie movie)
    {
        if (id != movie.Id)
        {
            return BadRequest();
        }
        _context.Movies.Update(movie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
        {
            return NotFound();
        }
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return NoContent();
    }
}
