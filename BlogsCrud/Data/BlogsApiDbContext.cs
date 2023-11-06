using BlogsCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogsCrud.Data
{
    public class BlogsApiDbContext : DbContext
    {
        public BlogsApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
