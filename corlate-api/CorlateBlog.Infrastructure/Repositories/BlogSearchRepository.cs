using System.Linq;
using CorlateBlog.Application.Repositories;
using CorlateBlog.Domain.Entities;
using CorlateBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CorlateBlog.Infrastructure.Repositories
{
    public class BlogSearchRepository : IBlogSearchRepository
    {
        private readonly CorlateBlogDbContext _context;

        public BlogSearchRepository(CorlateBlogDbContext context)
        {
            _context = context;
        }

        public IQueryable<Blog> GetBlogsForSearch()
        {
            return _context.Blogs
                .Include(b => b.PostTags)
                .Include(b => b.PostCategories)
                .AsQueryable();
        }
    }
}
