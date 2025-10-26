using CorlateBlog.Application.Repositories;
using CorlateBlog.Domain.Entities;
using CorlateBlog.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly CorlateBlogDbContext _context;
        public TagRepository(CorlateBlogDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<TagTbl>> GetAllTagTblsAsync()
        {
            return await Task.FromResult(_context.Tags.AsQueryable());
        }
    }
}
