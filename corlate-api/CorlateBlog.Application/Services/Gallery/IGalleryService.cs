using CorlateBlog.Application.Abstractions;
using CorlateBlog.Application.DTOs.Gallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.Services.Gallery
{
    public interface IGalleryService
    {
        Task<ResponseObject<IEnumerable<GalleryResponse>>> GetAllPhotosAsync(int page, int size);
    }
}
