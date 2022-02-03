using BlazorBlogApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlogApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
