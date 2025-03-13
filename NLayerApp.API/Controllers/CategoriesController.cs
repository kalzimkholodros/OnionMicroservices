using Microsoft.AspNetCore.Mvc;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.Models;
using NLayerApp.Core.Services;

namespace NLayerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                if (category == null)
                    return NotFound($"Category with id {id} not found");
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            try
            {
                if (categoryDto == null)
                    return BadRequest("Category data is null");

                if (string.IsNullOrWhiteSpace(categoryDto.Name))
                    return BadRequest("Category name is required");

                var category = new Category 
                { 
                    Name = categoryDto.Name,
                    CreatedDate = DateTime.UtcNow,
                    Products = new List<Product>()
                };

                await _categoryService.AddAsync(category);
                categoryDto.Id = category.Id;
                return Created($"api/categories/{category.Id}", categoryDto);
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? $" Inner exception: {ex.InnerException.Message}" : "";
                return StatusCode(500, $"Internal server error: {ex.Message}{innerException}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            try
            {
                if (categoryDto == null)
                    return BadRequest("Category data is null");

                if (string.IsNullOrWhiteSpace(categoryDto.Name))
                    return BadRequest("Category name is required");

                var category = new Category { Id = categoryDto.Id, Name = categoryDto.Name };
                await _categoryService.UpdateAsync(category);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                if (category == null)
                    return NotFound($"Category with id {id} not found");

                await _categoryService.RemoveAsync(category);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProducts(int id)
        {
            try
            {
                var category = await _categoryService.GetSingleCategoryByIdWithProductsAsync(id);
                if (category == null)
                    return NotFound($"Category with id {id} not found");
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
} 