using System.Linq;
using CorlateBlog.Domain.Entities;

namespace CorlateBlog.Application.Repositories
{
    public interface IBlogSearchRepository
    {
        IQueryable<Blog> GetBlogsForSearch();
    }
}
