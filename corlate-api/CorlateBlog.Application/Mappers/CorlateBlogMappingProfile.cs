using AutoMapper;
using CorlateBlog.Application.DTOs.BlogDTO.Request;
using CorlateBlog.Application.DTOs.BlogDTO.Response;
using CorlateBlog.Application.DTOs.Gallery;
using CorlateBlog.Application.DTOs.PostCommentDTOs.Request;
using CorlateBlog.Application.DTOs.PostCommentDTOs.Response;
using CorlateBlog.Application.DTOs.TagDTOs;
using CorlateBlog.Application.DTOs.PostCategory.Request;
using CorlateBlog.Application.DTOs.PostCategory.Response;
using CorlateBlog.Domain.Entities;

namespace CorlateBlog.Application.Mappers
{
    public class CorlateBlogMappingProfile : Profile
    {
        public CorlateBlogMappingProfile()
        {
            // POST CATEGORY
            CreateMap<CategoryRequest, PostCategoryTbl>();
            CreateMap<PostCategoryTbl, CategoryResponse>();
            // POST COMMENT
            CreateMap<PostCommentRequest, PostComment>().ReverseMap();
            CreateMap<PostComment, PostCommentResponse>().ReverseMap();
            // Tag
            CreateMap<TagTblRequest, TagTbl>().ReverseMap();
            CreateMap<TagTbl, TagTblResponse>().ReverseMap();
            CreateMap<TagTblRequest, TagTbl>().ReverseMap();
            CreateMap<TagTbl, TagTblResponse>().ReverseMap();
            // BLOG
            CreateMap<BlogRequest, Blog>().ReverseMap();
            CreateMap<Blog, BlogResponse>().ReverseMap();
            // Gallery
            CreateMap<GalleryResponse, Blog>().ReverseMap();
        }
    }
}
