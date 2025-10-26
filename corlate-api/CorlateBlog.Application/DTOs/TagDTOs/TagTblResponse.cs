using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.DTOs.TagDTOs
{
    public class TagTblResponse
    {
        public string Id { get; set; } = "";
       
        public string tag { get; set; } = "";
        public string BlogId { get; set; } = "";
    }
}
