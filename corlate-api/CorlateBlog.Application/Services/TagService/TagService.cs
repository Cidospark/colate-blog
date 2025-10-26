using AutoMapper;
using CorlateBlog.Application.Abstractions;
using CorlateBlog.Application.DTOs.TagDTOs;
using CorlateBlog.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.Services.TagService
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<ResponseObject<IEnumerable<TagTblResponse>>> GetAllTagTblsAsync(int page, int size)
        {
            var offset = PaginationHelper.GetOffset(page, size);
            size = offset <= 0 ? 10 : size;

            var tags = await _tagRepository.GetAllTagTblsAsync();
            return new ResponseObject<IEnumerable<TagTblResponse>>
            {
                StatusCode = 200,
                Message = "List of tags found",
                Data = tags.Skip(offset).Take(size)
                    .Select(tag => _mapper.Map<TagTblResponse>(tag)).ToList()
            };
        }

    }
}
