using CorlateBlog.Application.Abstractions;
using CorlateBlog.Application.DTOs.RepliesDTO;
using CorlateBlog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorlateBlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyService _replyService;

        public ReplyController(IReplyService replyService)
        {
            _replyService = replyService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ReplyRequest request)
        {
            var created = await _replyService.AddAsync(request);
            var response = new ResponseObject<ReplyResponse>
            {
                StatusCode = 201,
                Message = "Reply created",
                Data = created
            };

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _replyService.GetAllAsync();

            var response = new ResponseObject<IEnumerable<ReplyResponse>>
            {
                StatusCode = 200,
                Message = "Replies fetched",
                Data = list
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var reply = await _replyService.GetByIdAsync(id);
            if (reply == null)
            {
                return NotFound(new ResponseObject<object>
                {
                    StatusCode = 404,
                    Message = "Reply not found"
                });
            }

            return Ok(new ResponseObject<ReplyResponse>
            {
                StatusCode = 200,
                Message = "Reply fetched",
                Data = reply
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _replyService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new ResponseObject<bool>
                {
                    StatusCode = 404,
                    Message = "Reply not found",
                    Data = false
                });
            }

            return Ok(new ResponseObject<bool>
            {
                StatusCode = 200,
                Message = "Reply deleted successfully",
                Data = true
            });
        }
    }
}