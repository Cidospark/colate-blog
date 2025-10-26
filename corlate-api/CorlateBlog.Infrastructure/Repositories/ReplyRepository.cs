using CorlateBlog.Application.Repositories;
using CorlateBlog.Domain.Entities;
using CorlateBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Infrastructure.Repositories
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly CorlateBlogDbContext _context;

        public ReplyRepository(CorlateBlogDbContext context)
        {
            _context = context;
        }
        public async Task<ReplyTbl> AddAsync(ReplyTbl reply)
        {
            await _context.ReplyTbls.AddAsync(reply);
            await _context.SaveChangesAsync();
            return reply;
        }

        public async Task<IQueryable<ReplyTbl>> GetAllAsync()
        {
            var query = _context.ReplyTbls
                .AsNoTracking();
            return await Task.FromResult(query);
        }

        public async Task<ReplyTbl?> GetByIdAsync(string id)
        {
            return await _context.ReplyTbls
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public Task<IEnumerable<ReplyTbl>> GetRepliesByCommentIdAsync(string commentId)
        {
            var replies = _context.ReplyTbls
                .AsNoTracking()
                .Where(r => r.PostCommentId == commentId);
            return Task.FromResult(replies.AsEnumerable());
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await _context.ReplyTbls.FindAsync(id);
            if (entity == null) return false;
            _context.ReplyTbls.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}