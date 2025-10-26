using AutoMapper;
using CorlateBlog.Application.Abstractions;
using CorlateBlog.Application.DTOs.Gallery;
using CorlateBlog.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.Services.Gallery
{
    public class GalleryService : IGalleryService
    {
        private readonly IGalleryRepository _galleryRepository;
        private readonly IMapper _mapper;

        public GalleryService(IGalleryRepository galleryRepository, IMapper mapper)
        {
            _galleryRepository = galleryRepository;
            _mapper = mapper;
        }

        public async Task<ResponseObject<IEnumerable<GalleryResponse>>> GetAllPhotosAsync(int page, int size)
        {
            var offset = PaginationHelper.GetOffset(page, size);

            var photos = await _galleryRepository.GetAllPhotosAsync();

            var paginatedPhotos = photos.Skip(offset).Take(size)
                .Select(photo => _mapper.Map<GalleryResponse>(photo))
                .ToList();

            return new ResponseObject<IEnumerable<GalleryResponse>>
            {
                StatusCode = 200,
                Message = "Photos retrieved successfully",
                Data = paginatedPhotos
            };
        }
    }
}
