namespace CorlateBlog.Application.DTOs.Request
{
    public class BlogSearchRequest
    {
        public string? SearchTerm { get; set; }
        public string? Category { get; set; }
        public string? Tag { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
