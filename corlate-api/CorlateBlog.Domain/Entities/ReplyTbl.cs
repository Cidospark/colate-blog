namespace CorlateBlog.Domain.Entities
{
    public class ReplyTbl
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Reply { get; set; } = "";
        public string User { get; set; } = "";

        public string PostCommentId { get; set; } = "";
        public string BlogId { get; set; } = "";

        public Blog? Blog { get; set; }
        public PostComment? PostComment { get; set; }
    }
}