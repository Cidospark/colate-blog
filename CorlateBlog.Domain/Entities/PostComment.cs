namespace CorlateBlog.Domain.Entities
{
    public class PostComment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Comment { get; set; } = "";
        public string User { get; set; } = "";
        public ICollection<ReplyTbl> Replies { get; set; } = [];

        public string BlogId { get; set; } = "";
        public Blog? Blog { get; set; }
    }
}