using CorlateBlog.Application.Repositories;
using CorlateBlog.Application.Services.Identity;
using CorlateBlog.Infrastructure.Data;
using CorlateBlog.Infrastructure.Identity;
using CorlateBlog.Infrastructure.Repositories;
using CorlateBlog.Infrastructure.UserMapper;
using Microsoft.AspNetCore.Identity;
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

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<CorlateBlogDbContext>()
            .AddDefaultTokenProviders();


            services.AddScoped<IPostCommentRepository, PostCommentRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IGalleryRepository, GalleryRepository>();
            services.AddScoped<IBlogSearchRepository, BlogSearchRepository>();
            services.AddAutoMapper(typeof(UserMappingProfile));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IReplyRepository, ReplyRepository>();



            return services;
        }

        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roles = { "USER", "ADMIN", "MODERATOR" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
