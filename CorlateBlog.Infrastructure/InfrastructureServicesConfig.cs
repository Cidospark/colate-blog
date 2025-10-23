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
            // Configure PostgreSQL with Entity Framework Core
            services.AddDbContext<CorlateBlogDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


            // other infrastructure services like (repositories, logging, etc.) will go in here...
            services.AddScoped<IPostCommentRepository, PostCommentRepository>();


            return services;
        }
    }
}