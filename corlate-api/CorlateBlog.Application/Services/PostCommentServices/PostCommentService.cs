
using AutoMapper;
using CorlateBlog.Application.Abstractions;
using CorlateBlog.Application.DTOs.PostCommentDTOs.Request;
using CorlateBlog.Application.DTOs.PostCommentDTOs.Response;
using CorlateBlog.Application.Repositories;
using CorlateBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.Services.PostCommentServices
{
    public class PostCommentService : IPostCommentService
    {
        private readonly IPostCommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public PostCommentService(IPostCommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        private int GetOffset(int page, int size)
        {
            page = page < 1 ? 1 : page;
            size = size < 1 ? 10 : size;
            return (page - 1) * size;
        }

        public async Task<ResponseObject<PostCommentResponse>> AddCommentAsync(PostCommentRequest request)
        {
            var commentToAdd = _mapper.Map<PostComment>(request);
            await _commentRepository.AddCommentAsync(commentToAdd);
            var commentToReturn = _mapper.Map<PostCommentResponse>(commentToAdd);

            return new ResponseObject<PostCommentResponse>
            {
                StatusCode = 201,
                Message = "Comment Created!",
                Data = commentToReturn
            };
        }

        public async Task<ResponseObject<bool>> DeleteCommentAsync(string id)
        {
            var res = new ResponseObject<bool>();
            var comment = await _commentRepository.GetSingleCommentAsync(id);
            if (comment != null)
            {
                await _commentRepository.DeleteCommentAsync(comment);
                res.StatusCode = 200;
                res.Message = "Deleted!";
                res.Data = true;
            }
            else
            {
                res.StatusCode = 404;
                res.Message = "Not found.";
                res.Errors = new List<string> { $"Could not find comment with id: {id}" };
            }
            return res;
        }

        public async Task<ResponseObject<IEnumerable<PostCommentResponse>>> GetAllCommentsAsync(int page, int size)
        {
            var offset = GetOffset(page, size);

            var comments = await _commentRepository.GetAllCommentsAsync();
            var paginatedComments = comments
                .OrderByDescending(c => c.Id)
                .Skip(offset)
                .Take(size)
                .Select(comment => _mapper.Map<PostCommentResponse>(comment))
                .ToList();

            return new ResponseObject<IEnumerable<PostCommentResponse>>
            {
                StatusCode = 200,
                Message = "List of comments found",
                Data = paginatedComments
            };
        }

        //public async Task<ResponseObject<IEnumerable<PostCommentResponse>>> GetRecentCommentsAsync(int count)
        //{
        //    var comments = await _commentRepository.GetAllCommentsAsync();
        //    var recentComments = comments
        //        .OrderByDescending(c => c.Id)
        //        .Take(count)
        //        .Select(comment => _mapper.Map<PostCommentResponse>(comment))
        //        .ToList();

        //    return new ResponseObject<IEnumerable<PostCommentResponse>>
        //    {
        //        StatusCode = 200,
        //        Message = $"Found {recentComments.Count} recent comments.",
        //        Data = recentComments
        //    };
        //}

        public async Task<ResponseObject<IEnumerable<PostCommentResponse>>> GetRecentCommentsAsync(int page, int size)
        {
            // Re-using the pagination logic from your TodoApp
            var offset = GetOffset(page, size);

            var comments = await _commentRepository.GetAllCommentsAsync();
            var recentComments = comments
                .OrderByDescending(c => c.Id)
                .Skip(offset)
                .Take(size)
                .Select(comment => _mapper.Map<PostCommentResponse>(comment))
                .ToList();

            return new ResponseObject<IEnumerable<PostCommentResponse>>
            {
                StatusCode = 200,
                Message = "Recent comments retrieved successfully.",
                Data = recentComments
            };
        }

        public async Task<ResponseObject<PostCommentResponse>> GetSingleCommentAsync(string commentId)
        {
            var res = new ResponseObject<PostCommentResponse>();
            var comment = await _commentRepository.GetSingleCommentAsync(commentId);
            if (comment == null)
            {
                res.StatusCode = 404;
                res.Message = "Not found!";
                res.Errors = new List<string> { $"Could not find comment with id: {commentId}" };
            }
            else
            {
                res.StatusCode = 200;
                res.Message = "Comment found.";
                res.Data = _mapper.Map<PostCommentResponse>(comment);
            }
            return res;
        }

        public async Task<ResponseObject<PostCommentResponse>> UpdateCommentAsync(string id, PostCommentRequest request)
        {
            var res = new ResponseObject<PostCommentResponse>();
            var comment = await _commentRepository.GetSingleCommentAsync(id);
            if (comment != null)
            {

                _mapper.Map(request, comment);

                await _commentRepository.UpdateCommentAsync(comment);
                res.StatusCode = 200;
                res.Message = "Updated!";
                res.Data = _mapper.Map<PostCommentResponse>(comment);
            }
            else
            {
                res.StatusCode = 404;
                res.Message = "Not found.";
                res.Errors = new List<string> { $"Could not find comment with id: {id}" };
            }
            return res;
        }


    }
}
