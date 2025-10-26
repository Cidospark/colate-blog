using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorlateBlog.Application.DTOs.BlogDTO.Request
{
    public class BlogRequest
    {
        public string PostText { get; set; } = "";

        public string PostTitle { get; set; } = "";
        public string PostPhotoUrl { get; set; } = "";
    }
}