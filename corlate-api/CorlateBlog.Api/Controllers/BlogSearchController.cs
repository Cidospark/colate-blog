using CorlateBlog.Application.Interfaces;
using CorlateBlog.Application.DTOs.Request;
using CorlateBlog.Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace CorlateBlog.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BlogSearchController : ControllerBase
    {
        private readonly IBlogSearchService _blogSearchService;
        private readonly ILogger<BlogSearchController> _logger;

        public BlogSearchController(
            IBlogSearchService blogSearchService,
            ILogger<BlogSearchController> logger)
        {
            _blogSearchService = blogSearchService;
            _logger = logger;
        }

        /// <summary>
        /// Search blogs by search term with pagination
        /// </summary>
        /// <param name="searchTerm">Search term to find in post text, tags, or categories (optional - returns all if empty)</param>
        /// <param name="pageNumber">Page number (default: 1)</param>
        /// <param name="pageSize">Page size (default: 10)</param>
        /// <returns>Paged list of blog search results</returns>
        [HttpGet]
        public async Task<ActionResult<BlogSearchResponse>> SearchBlogs(
            [FromQuery] string? searchTerm = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var request = new BlogSearchRequest
                {
                    SearchTerm = searchTerm,
                    Category = null,
                    Tag = null,
                    PageNumber = pageNumber > 0 ? pageNumber : 1,
                    PageSize = pageSize > 0 && pageSize <= 100 ? pageSize : 10
                };

                var result = await _blogSearchService.SearchBlogsAsync(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while searching blogs");
                return StatusCode(500, new { message = "An error occurred while searching blogs" });
            }
        }
    }
}
