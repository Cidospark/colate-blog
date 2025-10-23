using CorlateBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.Repositories
{
    public interface IPostCommentRepository
    {
        Task AddCommentAsync(PostComment comment);
        Task<PostComment?> GetSingleCommentAsync(string commentId);
        Task<IQueryable<PostComment>> GetAllCommentsAsync();
        Task UpdateCommentAsync(PostComment comment);
        Task DeleteCommentAsync(PostComment comment);
    }
}
    