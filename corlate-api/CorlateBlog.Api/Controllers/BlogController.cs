using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorlateBlog.Application.DTOs;
using CorlateBlog.Application.DTOs.BlogDTO.Request;
using CorlateBlog.Application.Services;
using CorlateBlog.Application.Services.PostBlogServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorlateBlog.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/v1/[controller]")]
    public class BlogController : ControllerBase
    {

        private readonly ILogger<BlogController> _logger;
        private readonly IBlogService _blogService;

        public BlogController(ILogger<BlogController> logger, IBlogService blogService)
        {
            _logger = logger;
            _blogService = blogService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BlogRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _blogService.AddBlogAsync(request);
            return CreatedAtAction(nameof(GetSingle), new { id = result.Data?.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle([FromRoute] string id)
        {
            var result = await _blogService.GetSingleBlogAsync(id);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int size)
        {
            var result = await _blogService.GetAllBlogsAsync(page, size);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] BlogRequest request)
        {
            var result = await _blogService.UpdateBlogAsync(id, request);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var result = await _blogService.DeleteBlogAsync(id);
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

    }
}