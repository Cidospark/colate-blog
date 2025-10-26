using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorlateBlog.Application.Abstractions;
using CorlateBlog.Application.DTOs.BlogDTO.Request;
using CorlateBlog.Application.DTOs.BlogDTO.Response;

namespace CorlateBlog.Application.Services.PostBlogServices
{
    public interface IBlogService
    {
        Task<ResponseObject<BlogResponse>> AddBlogAsync(BlogRequest request);
        Task<ResponseObject<BlogResponse>> GetSingleBlogAsync(string blogId);
        Task<ResponseObject<IEnumerable<BlogResponse>>> GetAllBlogsAsync(int page, int size);
        Task<ResponseObject<BlogResponse>> UpdateBlogAsync(string id, BlogRequest request);
        Task<ResponseObject<bool>> DeleteBlogAsync(string id);
    }
}