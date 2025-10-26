using CorlateBlog.Application.Services.Gallery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorlateBlog.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService) 
        {
            _galleryService = galleryService;
        }

        [HttpGet("photos")]
        public async Task<IActionResult> GetPhotosAsync([FromQuery] int? page, [FromQuery] int? size)
        {
            // ✅ Default to featured if no pagination values provided
            int currentPage = page ?? 1;
            int pageSize = size ?? 6;  // 6 = featured, if not specified

            var response = await _galleryService.GetAllPhotosAsync(currentPage, pageSize);
            return StatusCode(response.StatusCode, response);
        }
    }
}
