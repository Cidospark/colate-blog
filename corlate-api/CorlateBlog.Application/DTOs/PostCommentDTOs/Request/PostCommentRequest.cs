using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.DTOs.PostCommentDTOs.Request
{
    public class PostCommentRequest
    {
        [Required(ErrorMessage = "Comment content is required")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Comment must be between 1 - 1000 characters")]
        public string Comment { get; set; } = "";

        [Required(ErrorMessage = "User is required")]
        public string User { get; set; } = "";

        [Required(ErrorMessage = "BlogId is required")]
        public string BlogId { get; set; } = "";
    }
}
