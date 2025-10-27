using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CorlateBlog.Application.Interfaces;
using CorlateBlog.Domain.Entities;
using CorlateBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CorlateBlog.Infrastructure.Repositories
{
    public class ArchiveRepository : IArchiveRepository
    {
        private readonly CorlateBlogDbContext _context;

        public ArchiveRepository(CorlateBlogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetAllAsync()
        {
            // Fetch only valid CreatedAt dates
            var blogs = await _context.Blogs
                .AsNoTracking()
                .Where(b => b.CreatedAt != default) // Exclude default 0001-01-01
                .Select(b => b.CreatedAt)
                .ToListAsync();

            if (!blogs.Any())
                return Enumerable.Empty<object>();

            var grouped = blogs
                .GroupBy(b => new { b.Year, b.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month),
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Year)
                .ThenByDescending(g => g.Month)
                .ToList();

            return grouped;
        }
    }
}
