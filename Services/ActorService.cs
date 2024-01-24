using FilmWebApi.Entities;
using FilmWebApi.Repositories;

namespace FilmWebApi.Services;

public interface IActorService
{
    Task<IEnumerable<Actor>> GetActors();
    Task<Actor> GetActor(int id);
    Task<Actor> AddActor(Actor actor);
    Task DeleteActor(int id);
    Task<Actor> UpdateActor(Actor actor);
}

public class ActorService : IActorService
{
    private readonly ActorRepository _actorRepository;

    public ActorService(ActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }

    public async Task<IEnumerable<Actor>> GetActors()
    {
        return await _actorRepository.GetActors();
    }

    public async Task<Actor> GetActor(int id)
    {
        return await _actorRepository.GetActor(id);
    }

    public async Task<Actor> AddActor(Actor actor)
    {
        return await _actorRepository.AddActor(actor);
    }

    public async Task DeleteActor(int id)
    {
        await _actorRepository.DeleteActor(id);
    }

    public async Task<Actor> UpdateActor(Actor actor)
    {
        return await _actorRepository.UpdateActor(actor);
    }
}
