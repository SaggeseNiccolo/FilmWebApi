﻿using FilmWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmWebApi.Repositories;

public class DirectorRepository
{
    private readonly ApplicationContext _context;

    public DirectorRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Director>> GetDirectors()
    {
        return await _context.Directors.ToListAsync();
    }

    public async Task<Director> GetDirector(Guid id)
    {
        var director = await _context.Directors.FindAsync(id) ?? throw new Exception("Director not found");

        return director;
    }

    public async Task<Director> AddDirector(Director director)
    {
        _context.Directors.Add(director);
        await _context.SaveChangesAsync();
        return director;
    }

    public async Task<IActionResult> DeleteDirector(Guid id)
    {
        var directorToDelete = await _context.Directors.FindAsync(id);

        if (directorToDelete != null)
        {
            _context.Directors.Remove(directorToDelete);
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        return new NotFoundResult();
    }

    public async Task<Director> UpdateDirector(Director director)
    {
        _context.Entry(director).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return director;
    }
}
