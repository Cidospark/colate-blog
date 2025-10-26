using AutoMapper;
using CorlateBlog.Application.DTOs.IdentityDTO.Request;
using CorlateBlog.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Infrastructure.UserMapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<ApplicationUser, UserRequest>().ReverseMap();
            CreateMap<UserRequest, ApplicationUser>().ReverseMap();
        }
    }
}
