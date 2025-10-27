
using CorlateBlog.Application.DTOs.PostCommentDTOs.Request;
using CorlateBlog.Application.Services;
using CorlateBlog.Application.Services.PostCommentServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CorlateBlog.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IPostCommentService _commentService;

        public CommentController(IPostCommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostCommentRequest request)
        {
            //
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _commentService.AddCommentAsync(request);

            return CreatedAtAction(nameof(GetSingle), new { id = result.Data?.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int size)
        {
            var result = await _commentService.GetAllCommentsAsync(page, size);
            return Ok(result);
        }

 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle([FromRoute] string id)
        {
            var result = await _commentService.GetSingleCommentAsync(id);
            //
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpGet("blog/{blogId}")]
        public async Task<IActionResult> GetCommentsByBlog(string blogId, [FromQuery] int page, [FromQuery] int size)
        {
            var result = await _commentService.GetCommentsByBlogIdAsync(blogId, page, size);
            return Ok(result);
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecent([FromQuery] int page, [FromQuery] int size)
        {
            var result = await _commentService.GetRecentCommentsAsync(page, size);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] PostCommentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _commentService.UpdateCommentAsync(id, request);
            //
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var result = await _commentService.DeleteCommentAsync(id);
            //
            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}