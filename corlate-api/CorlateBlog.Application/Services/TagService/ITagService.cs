using CorlateBlog.Application.Abstractions;
using CorlateBlog.Application.DTOs.TagDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.Services.TagService
{
    public interface ITagService
    {
        Task<ResponseObject<IEnumerable<TagTblResponse>>> GetAllTagTblsAsync(int page, int size);
    }
}
