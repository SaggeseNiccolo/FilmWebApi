using FilmWebApi.Entities;
using FilmWebApi.Repositories;

namespace FilmWebApi.Services;

public interface IDirectorService
{
    Task<IEnumerable<Director>> GetDirectors();
    Task<Director> GetDirector(Guid id);
    Task<Director> AddDirector(Director director);
    Task DeleteDirector(Guid id);
    Task<Director> UpdateDirector(Director director);
}

public class DirectorService : IDirectorService
{
    private readonly DirectorRepository _directorRepository;

    public DirectorService(DirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public async Task<IEnumerable<Director>> GetDirectors()
    {
        return await _directorRepository.GetDirectors();
    }

    public async Task<Director> GetDirector(Guid id)
    {
        return await _directorRepository.GetDirector(id);
    }

    public async Task<Director> AddDirector(Director director)
    {
        return await _directorRepository.AddDirector(director);
    }

    public async Task DeleteDirector(Guid id)
    {
        await _directorRepository.DeleteDirector(id);
    }

    public async Task<Director> UpdateDirector(Director director)
    {
        return await _directorRepository.UpdateDirector(director);
    }
}
