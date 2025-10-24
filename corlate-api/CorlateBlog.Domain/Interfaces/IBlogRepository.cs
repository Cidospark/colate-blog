using System.Collections.Generic;
using System.Threading.Tasks;
using CorlateBlog.Domain.Entities;

namespace CorlateBlog.Domain.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetAllBlogsAsync();
        Task<Blog?> GetBlogByIdAsync(string id);
    }
}
