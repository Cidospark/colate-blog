using CorlateBlog.Application.Services.Gallery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorlateBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService) 
        {
            _galleryService = galleryService;
        }

        [HttpGet("featured-photos")]
        public async Task<IActionResult> GetFeaturedPhotosAsync()
        {
            var response = await _galleryService.GetAllPhotosAsync(page: 1, size: 6);
            return StatusCode(response.StatusCode, response);
        }


        [HttpGet("all-photos")]
        public async Task<IActionResult> GetAllPhotosAsync([FromQuery] int page = 1, [FromQuery] int size = 12)
        {
            var response = await _galleryService.GetAllPhotosAsync(page, size);
            return StatusCode(response.StatusCode, response);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetPhotos([FromQuery] int page = 0, [FromQuery] int size = 0)
        //{
        //    if (page <= 0 || size <= 0)
        //    {
        //        var response = await _galleryService.GetAllPhotosAsync(1, 6);
        //        return StatusCode(response.StatusCode, response);
        //    }

        //    var pagedResponse = await _galleryService.GetAllPhotosAsync(page, size);
        //    return StatusCode(pagedResponse.StatusCode, pagedResponse);
        //}
    }
}
