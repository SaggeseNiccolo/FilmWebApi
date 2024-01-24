using FilmWebApi.Services;
using FilmWebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductionController : ControllerBase
{
    private readonly ProductionService _productionService;

    public ProductionController(ProductionService productionService)
    {
        _productionService = productionService;
    }

    [HttpGet]
    public async Task<IEnumerable<Production>> GetProductions()
    {
        return await _productionService.GetProductions();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Production>> GetProduction(int id)
    {
        return await _productionService.GetProduction(id);
    }

    [HttpPost]
    public async Task<ActionResult<Production>> AddProduction(Production production)
    {
        var newProduction = await _productionService.AddProduction(production);
        return CreatedAtAction(nameof(GetProduction), new { id = newProduction.Id }, newProduction);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduction(int id)
    {
        await _productionService.DeleteProduction(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Production>> UpdateProduction(Guid id, Production production)
    {
        if (id != production.Id)
        {
            return BadRequest();
        }

        return await _productionService.UpdateProduction(production);
    }
}
