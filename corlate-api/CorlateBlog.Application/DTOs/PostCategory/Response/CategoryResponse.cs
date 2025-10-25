using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.DTOs.PostCategory.Response
{
    public class CategoryResponse
    {
        public string Id { get; set; } = "";
        public string PostCategory { get; set; } = "";
        public string BlogId { get; set; } = "";
    }
}
