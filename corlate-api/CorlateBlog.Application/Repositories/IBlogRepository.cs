using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorlateBlog.Domain.Entities;

namespace CorlateBlog.Application.Repositories
{
    public interface IBlogRepository
    {
        Task AddBlogAsync(Blog blog);
        Task<Blog?> GetSingleBlogAsync(string id);
        Task<IQueryable<Blog>> GetAllBlogsAsync();
        Task UpdateBlogAsync(Blog blog);
        Task DeleteBlogAsync(Blog blog);
    }
}