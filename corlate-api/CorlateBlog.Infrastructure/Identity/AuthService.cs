using AutoMapper;
using CorlateBlog.Application.Abstractions;
using CorlateBlog.Application.DTOs.IdentityDTO.Request;
using CorlateBlog.Application.DTOs.IdentityDTO.Response;
using CorlateBlog.Application.Services.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Infrastructure.Identity
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AuthService(IConfiguration configuration,
                            IMapper mapper,
                            UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _mapper = mapper;
            _userManager = userManager;
        }
        private async Task<string> GenerateAccessTokenAsync(ApplicationUser user, List<string> roles, List<Claim> claims)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:Secret"] ?? "");

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("UserName", user.Email ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
            };

            foreach (var item in claims)
            {
                userClaims.Add(new Claim(item.Type, item.Value));
            }

            foreach (var role in roles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["JWT:LifeSpan"])),
                // Issuer = configuration["JWT:ValidIssuer"],
                // Audience = configuration["JWT:ValidAudience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var jwt = jwtSecurityTokenHandler.WriteToken(token);
            return await Task.FromResult(jwt);
        }

        public async Task<ResponseObject<LoginResponse>> Login(LoginRequest request)
        {
            // fetch user by email
            var appUser = await _userManager.FindByEmailAsync(request.Email);
          

            // if user is found using email
            if (appUser != null)
            {
                // check if password match
                if (await _userManager.CheckPasswordAsync(appUser, request.Password))
                {
                    var roles = (await _userManager.GetRolesAsync(appUser)).ToList();
                    var claims = (await _userManager.GetClaimsAsync(appUser)).ToList();
                    var newUser = new ApplicationUser
                    {
                        Id = appUser.Id,
                        Email = appUser.Email
                    };

                    // return login response on success
                    return new ResponseObject<LoginResponse>
                    {
                        StatusCode = 200,
                        Message = "Login is successful",
                        Data = new LoginResponse
                        {
                            AccessToken = await GenerateAccessTokenAsync(newUser, roles, claims),
                            User = new UserResponse
                            {
                                Id = appUser.Id,
                                Email = appUser.Email
                                //Roles = roles
                            },
                            Roles = roles,
                            Claims = claims.ToDictionary(c => c.Type, c => c.Value)
                        }
                    };
                }
            }

            // return errors on failure
            return new ResponseObject<LoginResponse>
            {
                StatusCode = 400,
                Message = "Login failed",
                Errors = new List<string> { "Invalid credentials" }
            };

        }

        public async Task<ResponseObject<UserResponse>> RegisterUser(UserRequest request)
        {
            // check if user already exists with email as email
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ResponseObject<UserResponse>
                {
                    StatusCode = 400,
                    Message = "User registration failed",
                    Errors = new List<string> { "Email already exists!" }
                };
            }

            // check if user already exists with email as username
            if (await _userManager.FindByNameAsync(request.Email) != null)
            {
                return new ResponseObject<UserResponse>
                {
                    StatusCode = 400,
                    Message = "User registration failed",
                    Errors = new List<string> { "Username already exists!" }
                };
            }

            var newUser = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return new ResponseObject<UserResponse>
                {
                    StatusCode = 400,
                    Message = "User registration failed",
                    Errors = errors
                };
            }
            // Assign default role
            await _userManager.AddToRoleAsync(newUser, "user");

            return new ResponseObject<UserResponse>
            {
                StatusCode = 200,
                Message = "User registered successfully",
                Data = new UserResponse
                {
                    Id = newUser.Id,
                    Email = newUser.Email
                }
            };
        }
    }
}
