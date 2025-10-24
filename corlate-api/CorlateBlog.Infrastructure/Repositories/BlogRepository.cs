using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorlateBlog.Application.Repositories;
using CorlateBlog.Domain.Entities;
using CorlateBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CorlateBlog.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CorlateBlogDbContext _context;
        public BlogRepository(CorlateBlogDbContext context)
        {
            _context = context;
        }

        public async Task AddBlogAsync(Blog blog)
        {
            await _context.AddAsync(blog);
            await _context.SaveChangesAsync();
        }

        public Task DeleteBlogAsync(Blog blog)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTodoAsync(Blog blog)
        {
            _context.Remove(blog);
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<Blog>> GetAllBlogsAsync()
        {
            return await Task.FromResult(_context.Blogs.AsQueryable());
        }



        public async Task<Blog?> GetSingleBlogAsync(string id)
        {
            var todo = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            return todo;
        }



        public async Task UpdateBlogAsync(Blog blog)
        {
            _context.Update(blog);
            await _context.SaveChangesAsync();

        }


    }
}