using CorlateBlog.Application.DTOs;

using CorlateBlog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CorlateBlog.Application.Services.TagService;

using System.Collections.Generic;
using System.Threading.Tasks;


namespace CorlateBlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

       
       

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int size)
        {
            var result = await _tagService.GetAllTagTblsAsync(page, size);
            return Ok(result);
        }
    }
}
