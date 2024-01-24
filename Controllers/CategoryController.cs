using FilmWebApi.Entities;
using FilmWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _categoryService.GetCategories();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        return await _categoryService.GetCategory(id);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> AddCategory(Category category)
    {
        var newCategory = await _categoryService.AddCategory(category);
        return CreatedAtAction(nameof(GetCategory), new { id = newCategory.Id }, newCategory);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteCategory(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Category>> UpdateCategory(Guid id, Category category)
    {
        if (id != category.Id)
        {
            return BadRequest();
        }

        return await _categoryService.UpdateCategory(category);
    }
}
