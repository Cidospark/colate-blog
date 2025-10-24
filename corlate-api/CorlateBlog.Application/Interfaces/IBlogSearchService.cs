using System.Threading.Tasks;
using CorlateBlog.Application.DTOs.Request;
using CorlateBlog.Application.DTOs.Response;

namespace CorlateBlog.Application.Interfaces
{
    public interface IBlogSearchService
    {
        Task<List<BlogSearchResponse>> SearchBlogsAsync(BlogSearchRequest request);
    }
}
