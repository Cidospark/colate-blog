using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.DTOs.TagDTOs
{
    public class TagTblRequest
    {
       
        public string tag { get; set; } = "";

        [Required(ErrorMessage = "User is required")]
        public string Id { get; set; } = "";

        [Required(ErrorMessage = "BlogId is required")]
        public string BlogId { get; set; } = "";
    }
}
