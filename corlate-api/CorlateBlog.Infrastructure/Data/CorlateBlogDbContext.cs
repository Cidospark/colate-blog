using CorlateBlog.Domain.Entities;
using CorlateBlog.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CorlateBlog.Infrastructure.Data
{
    public class CorlateBlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public CorlateBlogDbContext(DbContextOptions<CorlateBlogDbContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<PostCategoryTbl> PostCategoryTbls { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<ReplyTbl> ReplyTbls { get; set; }
        public DbSet<TagTbl> Tags { get; set; }

        
    }
}