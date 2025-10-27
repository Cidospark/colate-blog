using CorlateBlog.Api.Services;
using CorlateBlog.Application.DTOs;
using CorlateBlog.Application.Interfaces;

namespace CorlateBlog.Infrastructure.Services
{
    public class ArchiveService : IArchiveService
    {
        private readonly IArchiveRepository _repo;

        public ArchiveService(IArchiveRepository repo)
        {
            _repo = repo;
        }

        public async Task<ArchiveApiResponse<IEnumerable<ArchiveDto>>> GetAllAsync()
        {
            var groupedData = await _repo.GetAllAsync();

            // Map anonymous objects to ArchiveDto
            var archives = groupedData.Select(item => new ArchiveDto
            {
                Year = (int)item.GetType().GetProperty("Year")!.GetValue(item)!,
                Month = (string)item.GetType().GetProperty("Month")!.GetValue(item)!,
                Count = (int)item.GetType().GetProperty("Count")!.GetValue(item)!
            });

            return new ArchiveApiResponse<IEnumerable<ArchiveDto>>
            {
                StatusCode = 200,
                Message = "OK",
                Data = archives
            };
        }
    }
}
