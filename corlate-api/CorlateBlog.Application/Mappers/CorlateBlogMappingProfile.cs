using AutoMapper;
using CorlateBlog.Application.DTOs.BlogDTO.Request;
using CorlateBlog.Application.DTOs.BlogDTO.Response;
using CorlateBlog.Application.DTOs.PostCategory.Request;
using CorlateBlog.Application.DTOs.PostCategory.Response;
using CorlateBlog.Application.DTOs.PostCommentDTOs.Request;
using CorlateBlog.Application.DTOs.PostCommentDTOs.Response;
using CorlateBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            CreateMap<PostCommentRequest, PostComment>();

            CreateMap<PostComment, PostCommentResponse>();

            // BLOG
            CreateMap<BlogRequest, Blog>();

            CreateMap<Blog, BlogResponse>();
        }
    }
}