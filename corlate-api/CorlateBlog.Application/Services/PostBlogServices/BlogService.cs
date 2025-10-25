using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CorlateBlog.Application.Abstractions;
using CorlateBlog.Application.DTOs.BlogDTO.Request;
using CorlateBlog.Application.DTOs.BlogDTO.Response;
using CorlateBlog.Application.Repositories;
using CorlateBlog.Domain.Entities;

namespace CorlateBlog.Application.Services.PostBlogServices
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<ResponseObject<BlogResponse>> AddBlogAsync(BlogRequest request)
        {
            var blogToAdd = _mapper.Map<Blog>(request);
            await _blogRepository.AddBlogAsync(blogToAdd);
            var blogToReturn = _mapper.Map<BlogResponse>(blogToAdd);

            return new ResponseObject<BlogResponse>
            {
                StatusCode = 201,
                Message = "Todo Created!",
                Data = blogToReturn
            };
        }

        public async Task<ResponseObject<bool>> DeleteBlogAsync(string id)
        {
            var res = new ResponseObject<bool>();
            var blog = await _blogRepository.GetSingleBlogAsync(id);
            if (blog != null)
            {
                await _blogRepository.DeleteBlogAsync(blog);
                res.StatusCode = 200;
                res.Message = "Deleted!";
                res.Data = true;
            }
            else
            {
                res.StatusCode = 404;
                res.Message = "Not found.";
                res.Errors = new List<string> { $"Could not find blog with id: {id}" };
            }
            return res;

        }



        public async Task<ResponseObject<IEnumerable<BlogResponse>>> GetAllBlogsAsync(int page, int size)
        {
            var offset = PaginationHelper.GetOffset(page, size);
            size = offset <= 0 ? 10 : size;

            var todos = await _blogRepository.GetAllBlogsAsync();
            var total = todos.Count();
            var totalPages = (int)Math.Ceiling((double)total / size);
            return new ResponseObject<IEnumerable<BlogResponse>>
            {
                StatusCode = 200,
                Message = "List of todos found",
                Total = total,
                TotalPages = totalPages,
                Data = todos.Skip(offset).Take(size)
                    .Select(blog => _mapper.Map<BlogResponse>(blog)).ToList()
            };
        }

        public async Task<ResponseObject<BlogResponse>> GetSingleBlogAsync(string blogId)
        {
            var res = new ResponseObject<BlogResponse>();
            var blog = await _blogRepository.GetSingleBlogAsync(blogId);
            if (blog == null)
            {
                res.StatusCode = 404;
                res.Message = "Not found!";
                res.Errors = new List<string> { $"Could not find blog with id: {blogId}" };
            }
            else
            {
                res.StatusCode = 200;
                res.Message = "Todo found.";
                res.Data = _mapper.Map<BlogResponse>(blog);
            }
            return res;
        }



        public async Task<ResponseObject<BlogResponse>> UpdateBlogAsync(string id, BlogRequest request)
        {
            var res = new ResponseObject<BlogResponse>();
            var blog = await _blogRepository.GetSingleBlogAsync(id);
            if (blog != null)
            {
                // update the blog object
                var todoToUpdate = _mapper.Map(request, blog);
                await _blogRepository.UpdateBlogAsync(blog);
                res.StatusCode = 200;
                res.Message = "Updated!";
                res.Data = _mapper.Map<BlogResponse>(todoToUpdate);
            }
            else
            {
                res.StatusCode = 404;
                res.Message = "Not found.";
                res.Errors = new List<string> { $"Could not find blog with id: {id}" };
            }
            return res;
        }


    }
}