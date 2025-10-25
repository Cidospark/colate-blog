using CorlateBlog.Application.DTOs.Response;
using CorlateBlog.Application.DTOs.Request;
using CorlateBlog.Application.Interfaces;
using CorlateBlog.Application.Repositories;
using CorlateBlog.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CorlateBlog.Application.Services
{
    public class BlogSearchService : IBlogSearchService
    {
        private readonly IBlogSearchRepository _blogSearchRepository;

        public BlogSearchService(IBlogSearchRepository blogSearchRepository)
        {
            _blogSearchRepository = blogSearchRepository;
        }

        public async Task<List<BlogSearchResponse>> SearchBlogsAsync(BlogSearchRequest request)
        {
            var query = _blogSearchRepository.GetBlogsForSearch();

            // Filter by search term (searches in post text, tags, and categories)
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.ToLower();
                query = query.Where(b =>
                    b.PostText.ToLower().Contains(searchTerm) ||
                    b.PostTags.Any(t => t.Tag.ToLower().Contains(searchTerm)) ||
                    b.PostCategories.Any(c => c.PostCategory.ToLower().Contains(searchTerm))
                );
            }

            // Filter by category
            if (!string.IsNullOrWhiteSpace(request.Category))
            {
                var category = request.Category.ToLower();
                query = query.Where(b =>
                    b.PostCategories.Any(c => c.PostCategory.ToLower().Contains(category))
                );
            }

            // Filter by tag
            if (!string.IsNullOrWhiteSpace(request.Tag))
            {
                var tag = request.Tag.ToLower();
                query = query.Where(b =>
                    b.PostTags.Any(t => t.Tag.ToLower().Contains(tag))
                );
            }

            // Get total count before pagination
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize);

            // Calculate offset using PaginationHelper
            var offset = PaginationHelper.GetOffset(request.PageNumber, request.PageSize);

            // Apply pagination and execute query
            var blogs = await query
                .Skip(offset)
                .Take(request.PageSize)
                .Select(b => new BlogSearchItemDto
                {
                    Id = b.Id,
                    PostText = b.PostText,
                    PostPhotoUrl = b.PostPhotoUrl,
                    PostLikesCount = b.PostLikesCount,
                    CommentsReplies = b.CommentsReplies,
                    CommentCount = b.CommentCount,
                    PostTags = b.PostTags.Select(t => t.Tag).ToList(),
                    PostCategories = b.PostCategories.Select(c => c.PostCategory).ToList()
                })
                .ToListAsync();

            return new BlogSearchResponse
            {
                Data = blogs,
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalCount,
                TotalPages = totalPages
            };
        }
    }
}
