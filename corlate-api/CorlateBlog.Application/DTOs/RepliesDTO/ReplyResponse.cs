using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.DTOs.RepliesDTO
{
    public class ReplyResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Reply { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string PostCommentId { get; set; } = string.Empty;
        public string BlogId { get; set; } = string.Empty;
    }
}
