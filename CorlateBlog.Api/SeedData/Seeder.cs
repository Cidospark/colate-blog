using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorlateBlog.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CorlateBlog.Infrastructure.Data
{
    public static class Seeder
    {
        public static async Task SeedMe(IServiceProvider serviceProvider)
        {
             // Create a scope to resolve services
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CorlateBlogDbContext>();

            if(!context.Blogs.Any())
            {
                var data = await File.ReadAllTextAsync("SeedData/blog_posts_dummy_data.json");
                var blogPosts = JsonConvert.DeserializeObject<List<Blog>>(data);

                if (blogPosts == null)
                {
                    throw new InvalidOperationException("Failed to deserialize category data");
                }
                foreach (var post in blogPosts)
                {
                    context.Blogs.Add(post);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}