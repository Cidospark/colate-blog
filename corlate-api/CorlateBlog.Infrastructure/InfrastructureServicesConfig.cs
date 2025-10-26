using CorlateBlog.Application.Repositories;
using CorlateBlog.Infrastructure.Data;
using CorlateBlog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagmeentSystem.Infrastructure
{
    public static class InfrastructureServicesConfig
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CorlateBlogDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IPostCommentRepository, PostCommentRepository>();


            services.AddScoped<ITagRepository, TagRepository>();

            services.AddScoped<IBlogRepository, BlogRepository>();


            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();



            return services;
        }
    }
}