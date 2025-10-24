using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorlateBlog.Domain.Entities
{
    public class Blog
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string PostText { get; set; } = "";
        public string PostPhotoUrl { get; set; } = "";
        public int PostLikesCount { get; set; }
        public int CommentsReplies { get; set; }
        public int CommentCount { get; set; }
        public ICollection<TagTbl> PostTags { get; set; } = [];
        public ICollection<PostComment> PostComments { get; set; } = [];
        public ICollection<PostCategoryTbl> PostCategories { get; set; } = [];
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}