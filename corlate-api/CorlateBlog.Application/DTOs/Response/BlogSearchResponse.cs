namespace CorlateBlog.Application.DTOs.Response
{
    public class BlogSearchResponse
    {
        public string Id { get; set; } = string.Empty;
        public string PostText { get; set; } = string.Empty;
        public string PostPhotoUrl { get; set; } = string.Empty;
        public int PostLikesCount { get; set; }
        public int CommentsReplies { get; set; }
        public int CommentCount { get; set; }
        public List<string> PostTags { get; set; } = new();
        public List<string> PostCategories { get; set; } = new();
    }
}
