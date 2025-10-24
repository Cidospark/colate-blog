namespace CorlateBlog.Domain.Entities
{
    public class CommentTbl
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Comment { get; set; } = "";

        public string PostCommentId { get; set; } = "";
        public string BlogId { get; set; } = "";
        public Blog? Blog { get; set; }
        public PostComment? PostComment { get; set; }
    }
}