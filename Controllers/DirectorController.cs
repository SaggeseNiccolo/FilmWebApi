using FilmWebApi.Services;
using FilmWebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DirectorController : ControllerBase
{
    private readonly IDirectorService _directorService;

    public DirectorController(IDirectorService directorService)
    {
        _directorService = directorService;
    }

    [HttpGet]
    public async Task<IEnumerable<Director>> GetDirectors()
    {
        return await _directorService.GetDirectors();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Director>> GetDirector(Guid id)
    {
        return await _directorService.GetDirector(id);
    }

    [HttpPost]
    public async Task<ActionResult<Director>> AddDirector(Director director)
    {
        var newDirector = await _directorService.AddDirector(director);
        return CreatedAtAction(nameof(GetDirector), new { id = newDirector.Id }, newDirector);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDirector(Guid id)
    {
        await _directorService.DeleteDirector(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Director>> UpdateDirector(Guid id, Director director)
    {
        if (id != director.Id)
        {
            return BadRequest();
        }

        return await _directorService.UpdateDirector(director);
    }
}
