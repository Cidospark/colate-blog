using CorlateBlog.Domain.Entities;
using CorlateBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CorlateBlog.Application.Repositories.ArchiveRepo;
using System.Globalization;

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
            var grouped = await _context.Blogs
                .GroupBy(b => new { b.CreatedAt.Year, b.CreatedAt.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Year)
                .ThenByDescending(g => g.Month)
                .ToListAsync(); // Query executes here in SQL

            // Convert to month names after EF has fetched results
            return grouped.Select(g => new
            {
                g.Year,
                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Month),
                g.Count
            });
        }
    }
}
