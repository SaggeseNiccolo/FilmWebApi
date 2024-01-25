using FilmWebApi.Repositories;
using FilmWebApi.Entities;

namespace FilmWebApi.Services;

public interface IProductionService
{
    Task<IEnumerable<Production>> GetProductions();
    Task<Production> GetProduction(Guid id);
    Task<Production> AddProduction(Production production);
    Task DeleteProduction(Guid id);
    Task<Production> UpdateProduction(Production production);
}

public class ProductionService : IProductionService
{
    private readonly ProductionRepository _productionRepository;

    public ProductionService(ProductionRepository productionRepository)
    {
        _productionRepository = productionRepository;
    }

    public async Task<IEnumerable<Production>> GetProductions()
    {
        return await _productionRepository.GetProductions();
    }

    public async Task<Production> GetProduction(Guid id)
    {
        return await _productionRepository.GetProduction(id);
    }

    public async Task<Production> AddProduction(Production production)
    {
        return await _productionRepository.AddProduction(production);
    }

    public async Task DeleteProduction(Guid id)
    {
        await _productionRepository.DeleteProduction(id);
    }

    public async Task<Production> UpdateProduction(Production production)
    {
        return await _productionRepository.UpdateProduction(production);
    }
}
