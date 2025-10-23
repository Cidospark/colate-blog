namespace CorlateBlog.Domain.Entities
{
    public class TagTbl
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Tag { get; set; } = "";
        public string BlogId { get; set; } = "";
        public Blog? Blog { get; set; }
    }
}