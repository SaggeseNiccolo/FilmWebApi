using FilmWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmWebApi.Repositories;

public class CategoryRepository
{
    private readonly ApplicationContext _context;

    public CategoryRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id) ?? throw new Exception("Category not found");

        return category;
    }

    public async Task<Category> AddCategory(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task DeleteCategory(int id)
    {
        var categoryToDelete = await _context.Categories.FindAsync(id);

        if (categoryToDelete != null)
        {
            _context.Categories.Remove(categoryToDelete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Category> UpdateCategory(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return category;
    }
}
