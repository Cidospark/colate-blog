using CorlateBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.Repositories
{
    public interface IReplyRepository
    {
        Task<ReplyTbl> AddAsync(ReplyTbl reply);
        Task<IQueryable<ReplyTbl>> GetAllAsync(int page, int size);
        Task<ReplyTbl?> GetByIdAsync(string id);
        Task<IEnumerable<ReplyTbl>> GetRepliesByCommentIdAsync(string commentId);
        Task<bool> DeleteAsync(string id);
    }
}