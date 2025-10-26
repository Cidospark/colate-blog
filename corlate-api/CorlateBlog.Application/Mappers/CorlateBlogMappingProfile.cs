using AutoMapper;
<<<<<<< HEAD
using CorlateBlog.Application.DTOs.Gallery;
=======
using CorlateBlog.Application.DTOs.BlogDTO.Request;
using CorlateBlog.Application.DTOs.BlogDTO.Response;
>>>>>>> develop
using CorlateBlog.Application.DTOs.PostCommentDTOs.Request;
using CorlateBlog.Application.DTOs.PostCommentDTOs.Response;
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
            //Gallery
            CreateMap<GalleryResponse, Blog>().ReverseMap();
=======
            // BLOG
            CreateMap<BlogRequest, Blog>();

            CreateMap<Blog, BlogResponse>();
>>>>>>> develop
        }
    }
}