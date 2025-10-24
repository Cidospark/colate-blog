
using Microsoft.AspNetCore.Mvc;
using CorlateBlog.Application.DTOs.PostCommentDTOs.Request;
using CorlateBlog.Application.Services;
using System.Threading.Tasks;
using CorlateBlog.Application.Services.PostCommentServices;

namespace CorlateBlog.Api.Controllers
{
    [ApiController]
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

        [HttpGet("recent")]
        //public async Task<IActionResult> GetRecent([FromQuery] int count = 5)
        //{
        //    var result = await _commentService.GetRecentCommentsAsync(count);
        //    return Ok(result);
        //}
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