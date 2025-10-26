using AutoMapper;
using CorlateBlog.Application.DTOs.BlogDTO.Request;
using CorlateBlog.Application.DTOs.BlogDTO.Response;
using CorlateBlog.Application.DTOs.PostCommentDTOs.Request;
using CorlateBlog.Application.DTOs.PostCommentDTOs.Response;
using CorlateBlog.Application.DTOs.TagDTOs;
using CorlateBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Application.Mappers
{
    public class CorlateBlogMappingProfile : Profile
    {
        public CorlateBlogMappingProfile()
        {



            // POST COMMENT
            CreateMap<PostCommentRequest, PostComment>();

            CreateMap<PostComment, PostCommentResponse>();
<<<<<<< HEAD
            CreateMap<TagTblRequest, TagTbl>();

            CreateMap<TagTbl, TagTblResponse>();
=======

            // BLOG
            CreateMap<BlogRequest, Blog>();

            CreateMap<Blog, BlogResponse>();
>>>>>>> develop
        }
    }
}