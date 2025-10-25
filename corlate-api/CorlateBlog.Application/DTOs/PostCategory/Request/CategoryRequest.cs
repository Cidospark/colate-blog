using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.DTOs.PostCategory.Request
{
    public class CategoryRequest
    {
        public string PostCategory { get; set; } = "";
        public string BlogId { get; set; } = "";
    }
}
