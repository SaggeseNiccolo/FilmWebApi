using FilmWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmWebApi.Repositories;

public class ActorRepository
{
    private readonly ApplicationContext _context;

    public ActorRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Actor>> GetActors()
    {
        return await _context.Actors.ToListAsync();
    }

    public async Task<Actor> GetActor(int id)
    {
        var actor = await _context.Actors.FindAsync(id) ?? throw new Exception("Actor not found");

        return actor;
    }

    public async Task<Actor> AddActor(Actor actor)
    {
        _context.Actors.Add(actor);
        await _context.SaveChangesAsync();
        return actor;
    }

    public async Task DeleteActor(int id)
    {
        var actorToDelete = await _context.Actors.FindAsync(id);

        if (actorToDelete != null)
        {
            _context.Actors.Remove(actorToDelete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Actor> UpdateActor(Actor actor)
    {
        _context.Entry(actor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return actor;
    }
}
