using FilmWebApi.Entities;
using FilmWebApi.Repositories;

namespace FilmWebApi.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category> GetCategory(Guid id);
    Task<Category> AddCategory(Category category);
    Task DeleteCategory(Guid id);
    Task<Category> UpdateCategory(Category category);
}

public class CategoryService : ICategoryService
{
    private readonly CategoryRepository _categoryRepository;

    public CategoryService(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _categoryRepository.GetCategories();
    }

    public async Task<Category> GetCategory(Guid id)
    {
        return await _categoryRepository.GetCategory(id);
    }

    public async Task<Category> AddCategory(Category category)
    {
        return await _categoryRepository.AddCategory(category);
    }

    public async Task DeleteCategory(Guid id)
    {
        await _categoryRepository.DeleteCategory(id);
    }

    public async Task<Category> UpdateCategory(Category category)
    {
        return await _categoryRepository.UpdateCategory(category);
    }
}
