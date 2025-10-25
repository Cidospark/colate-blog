using CorlateBlog.Application.Services.PostBlogServices;
using CorlateBlog.Application.Services.PostCommentServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Mappers;

namespace CorlateBlog.Application
{
    public static class ApplicationServiceConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPostCommentService, PostCommentService>();
            services.AddScoped<IBlogService, BlogService>();

            services.AddAutoMapper(typeof(CorlateBlogMappingProfile));

            return services;
        }
    }
}
