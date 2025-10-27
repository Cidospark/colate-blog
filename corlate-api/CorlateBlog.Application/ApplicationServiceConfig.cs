using CorlateBlog.Application.Interfaces;
using CorlateBlog.Application.Mappers;
using CorlateBlog.Application.Services;
using CorlateBlog.Application.Services.Gallery;
using CorlateBlog.Application.Services.PostBlogServices;
using CorlateBlog.Application.Services.PostCommentServices;
using CorlateBlog.Application.Services.TagService;
using CorlateBlog.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using CorlateBlog.Application.Mappers;

namespace CorlateBlog.Application
{
    public static class ApplicationServiceConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPostCommentService, PostCommentService>();

            services.AddScoped<ITagService, TagService>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IReplyService, ReplyService>();



            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IBlogService, BlogService>();

            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<IBlogSearchService, BlogSearchService>();

            services.AddAutoMapper(typeof(CorlateBlogMappingProfile));
            services.AddScoped<Api.Services.IArchiveService, ArchiveService>(); 


            return services;
        }
    }
}
