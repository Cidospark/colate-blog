using CorlateBlog.Application.DTOs.RepliesDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorlateBlog.Application.Services
{
    public interface IReplyService
    {
        Task<ReplyResponse> AddAsync(ReplyRequest request);
        Task<IEnumerable<ReplyResponse>> GetAllAsync();
        Task<ReplyResponse?> GetByIdAsync(string id);
        Task<bool> DeleteAsync(string id);
    }
}