using CorlateBlog.Application.Repositories;
using CorlateBlog.Domain.Entities;
using CorlateBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CorlateBlog.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CorlateBlogDbContext _context;

        public CategoryRepository(CorlateBlogDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(PostCategoryTbl category)
        {
            await _context.PostCategoryTbls.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<PostCategoryTbl?> GetSingleCategoryAsync(string id)
        {
            return await _context.PostCategoryTbls.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IQueryable<PostCategoryTbl>> GetAllCategoriesAsync()
        {
            return await Task.FromResult(_context.PostCategoryTbls.AsQueryable());
        }

        public async Task UpdateCategoryAsync(PostCategoryTbl category)
        {
            _context.PostCategoryTbls.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(PostCategoryTbl category)
        {
            _context.PostCategoryTbls.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
