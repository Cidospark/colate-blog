using CorlateBlog.Application.Services.PostBlogServices;
using CorlateBlog.Application.Services.Gallery;
using CorlateBlog.Application.Services;
using CorlateBlog.Application.Services.PostCommentServices;
using CorlateBlog.Application.Services.TagService;
using CorlateBlog.Application.Interfaces;

using Microsoft.Extensions.DependencyInjection;
using TodoApp.Application.Mappers;

namespace CorlateBlog.Application
{
    public static class ApplicationServiceConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPostCommentService, PostCommentService>();

            services.AddScoped<ITagService, TagService>();

            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IGalleryService, GalleryService>();

            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IBlogSearchService, BlogSearchService>();

            services.AddAutoMapper(typeof(CorlateBlogMappingProfile));

            return services;
        }
    }
}
