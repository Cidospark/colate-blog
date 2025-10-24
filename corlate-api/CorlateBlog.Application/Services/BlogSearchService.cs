using CorlateBlog.Application.DTOs.Response;
using CorlateBlog.Application.DTOs.Request;
using CorlateBlog.Application.Interfaces;
using CorlateBlog.Application.Repositories;

namespace CorlateBlog.Application.Services
{
    public class BlogSearchService : IBlogSearchService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogSearchService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<BlogSearchResponse>> SearchBlogsAsync(BlogSearchRequest request)
        {
            var allBlogs = await _blogRepository.GetAllBlogsAsync();
            var query = allBlogs.AsQueryable();

            // Filter by search term (searches in post text)
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

            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize);

            // Apply pagination
            var pagedBlogs = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(b => new BlogSearchResponse
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
                .ToList();

            return pagedBlogs;
        }
    }
}
