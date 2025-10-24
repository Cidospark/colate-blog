namespace CorlateBlog.Application.DTOs
{
    public class ArchiveDto
    {
        public int Year { get; set; }
        public string Month { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}
