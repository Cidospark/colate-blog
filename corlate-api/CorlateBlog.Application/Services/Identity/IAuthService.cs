using CorlateBlog.Application.Abstractions;
using CorlateBlog.Application.DTOs.IdentityDTO.Request;
using CorlateBlog.Application.DTOs.IdentityDTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.Services.Identity
{
    public interface IAuthService
    {
        Task<ResponseObject<UserResponse>> RegisterUser(UserRequest request);
        Task<ResponseObject<LoginResponse>> Login(LoginRequest request);
    }
}
