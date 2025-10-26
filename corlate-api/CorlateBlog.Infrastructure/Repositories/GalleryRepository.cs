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
    public class GalleryRepository : IGalleryRepository
    {
        private readonly CorlateBlogDbContext _context;

        public GalleryRepository(CorlateBlogDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Blog>> GetAllPhotosAsync()
        {

            var photos = _context.Blogs
                .Where(b => !string.IsNullOrEmpty(b.PostPhotoUrl))
                .Select(b => new Blog
                {
                    Id = b.Id,
                    PostPhotoUrl = b.PostPhotoUrl
                })
                .AsQueryable();

             return await Task.FromResult(photos);
        }
    }
}
