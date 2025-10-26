using CorlateBlog.Application.DTOs.PostCategory.Request;
using CorlateBlog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CorlateBlog.Api.Controllers
{
    [Route("[controller]")]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] CategoryRequest request)
        //{
        //    var result = await _categoryService.AddCategoryAsync(request);
        //    return CreatedAtAction(nameof(GetSingle), new { id = result.Data?.Id }, result);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle([FromRoute] string id)
        {
            var result = await _categoryService.GetSingleCategoryAsync(id);
            return result.StatusCode == 200 ? Ok(result) : NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            var result = await _categoryService.GetAllCategoriesAsync(page, size);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllCategoriesAsync();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] CategoryRequest request)
        {
            var result = await _categoryService.UpdateCategoryAsync(id, request);
            return result.StatusCode == 200 ? Ok(result) : NotFound(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            return result.StatusCode == 200 ? Ok(result) : NotFound(result);
        }
    }
}
