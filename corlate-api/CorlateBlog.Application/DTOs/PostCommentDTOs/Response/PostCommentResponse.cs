using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.DTOs.PostCommentDTOs.Response
{
    public class PostCommentResponse
    {
        public string Id { get; set; } = "";
        public string Comment { get; set; } = "";
        public string User { get; set; } = "";
        public string BlogId { get; set; } = "";
    }
}
