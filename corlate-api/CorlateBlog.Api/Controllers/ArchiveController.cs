using CorlateBlog.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorlateBlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArchiveController : ControllerBase
    {
        private readonly IArchiveService _svc;

        public ArchiveController(IArchiveService svc)
        {
            _svc = svc;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _svc.GetAllAsync();
            return StatusCode(result.StatusCode, result);
        }
    }
}
