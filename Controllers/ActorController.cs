using FilmWebApi.Entities;
using FilmWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorController : ControllerBase
{
    private readonly IActorService _actorService;

    public ActorController(IActorService actorService)
    {
        _actorService = actorService;
    }

    [HttpGet]
    public async Task<IEnumerable<Actor>> GetActors()
    {
        return await _actorService.GetActors();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Actor>> GetActor(Guid id)
    {
        return await _actorService.GetActor(id);
    }

    [HttpPost]
    public async Task<ActionResult<Actor>> AddActor(Actor actor)
    {
        var newActor = await _actorService.AddActor(actor);
        return CreatedAtAction(nameof(GetActor), new { id = newActor.Id }, newActor);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActor(Guid id)
    {
        await _actorService.DeleteActor(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Actor>> UpdateActor(Guid id, Actor actor)
    {
        if (id != actor.Id)
        {
            return BadRequest();
        }

        return await _actorService.UpdateActor(actor);
    }
}
