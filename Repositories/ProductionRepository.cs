﻿using FilmWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmWebApi.Repositories;

public class ProductionRepository
{
    private readonly ApplicationContext _context;

    public ProductionRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Production>> GetProductions()
    {
        return await _context.Productions.ToListAsync();
    }

    public async Task<Production> GetProduction(int id)
    {
        var production = await _context.Productions.FindAsync(id) ?? throw new Exception("Production not found");

        return production;
    }

    public async Task<Production> AddProduction(Production production)
    {
        _context.Productions.Add(production);
        await _context.SaveChangesAsync();
        return production;
    }

    public async Task DeleteProduction(int id)
    {
        var productionToDelete = await _context.Productions.FindAsync(id);

        if (productionToDelete != null)
        {
            _context.Productions.Remove(productionToDelete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Production> UpdateProduction(Production production)
    {
        _context.Entry(production).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return production;
    }
}