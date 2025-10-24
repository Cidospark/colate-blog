using CorlateBlog.Application.DTOs;

namespace CorlateBlog.Api.Services
{
    public interface IArchiveService
    {
        Task<ArchiveApiResponse<IEnumerable<ArchiveDto>>> GetAllAsync();
    }
}
