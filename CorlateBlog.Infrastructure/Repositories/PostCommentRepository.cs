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
    public class PostCommentRepository : IPostCommentRepository
    {
            // I am assuming your DbContext is named 'CorlateBlogDbContext'
            private readonly CorlateBlogDbContext _context;
            public PostCommentRepository(CorlateBlogDbContext context)
            {
                _context = context;
            }

            public async Task AddCommentAsync(PostComment comment)
            {
                await _context.PostComments.AddAsync(comment);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteCommentAsync(PostComment comment)
            {
                _context.PostComments.Remove(comment);
                await _context.SaveChangesAsync();
            }

            public async Task<IQueryable<PostComment>> GetAllCommentsAsync()
            {
                // This follows the efficient pattern from your TodoRepository
                return await Task.FromResult(_context.PostComments.AsQueryable());
            }

            public async Task<PostComment?> GetSingleCommentAsync(string commentId)
            {
                return await _context.PostComments.FirstOrDefaultAsync(c => c.Id == commentId);
            }

            public async Task UpdateCommentAsync(PostComment comment)
            {
                _context.PostComments.Update(comment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
}
