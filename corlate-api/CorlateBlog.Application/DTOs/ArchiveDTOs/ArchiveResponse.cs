namespace CorlateBlog.Application.DTOs
{
    public class ArchiveApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new();
        public T? Data { get; set; }
    }
}
