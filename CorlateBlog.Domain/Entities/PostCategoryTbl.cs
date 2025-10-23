namespace CorlateBlog.Domain.Entities
{
    public class PostCategoryTbl
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string PostCategory { get; set; } = "";


        public string BlogId { get; set; } = "";
        public Blog? Blog { get; set; }
    }
}