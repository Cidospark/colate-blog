using CorlateBlog.Application.Abstractions;
using CorlateBlog.Application.DTOs.PostCommentDTOs.Request;
using CorlateBlog.Application.DTOs.PostCommentDTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.Services.PostComment
{
    public interface IPostCommentService
    {
        Task<ResponseObject<PostCommentResponse>> AddCommentAsync(PostCommentRequest request);
        // GET by ID
        Task<ResponseObject<PostCommentResponse>> GetSingleCommentAsync(string commentId);
        // GET All (Paginated)
        Task<ResponseObject<IEnumerable<PostCommentResponse>>> GetAllCommentsAsync(int page, int size);
        // PUT
        Task<ResponseObject<PostCommentResponse>> UpdateCommentAsync(string id, PostCommentRequest request);
        // DELETE
        Task<ResponseObject<bool>> DeleteCommentAsync(string id);
        // GET Recent
        Task<ResponseObject<IEnumerable<PostCommentResponse>>> GetRecentCommentsAsync(int count);
    }
}
