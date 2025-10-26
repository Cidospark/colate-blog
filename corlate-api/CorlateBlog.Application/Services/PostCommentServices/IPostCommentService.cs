using CorlateBlog.Application.Abstractions;
using CorlateBlog.Application.DTOs.PostCommentDTOs.Request;
using CorlateBlog.Application.DTOs.PostCommentDTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.Services.PostCommentServices
{
    public interface IPostCommentService
    {
        Task<ResponseObject<PostCommentResponse>> AddCommentAsync(PostCommentRequest request);
        Task<ResponseObject<PostCommentResponse>> GetSingleCommentAsync(string commentId);
        Task<ResponseObject<IEnumerable<PostCommentResponse>>> GetAllCommentsAsync(int page, int size);

        Task<ResponseObject<IEnumerable<PostCommentResponse>>> GetCommentsByBlogIdAsync(string blogId, int page, int size);
        Task<ResponseObject<PostCommentResponse>> UpdateCommentAsync(string id, PostCommentRequest request);
        Task<ResponseObject<bool>> DeleteCommentAsync(string id);
        Task<ResponseObject<IEnumerable<PostCommentResponse>>> GetRecentCommentsAsync(int page, int size);
    }
}
