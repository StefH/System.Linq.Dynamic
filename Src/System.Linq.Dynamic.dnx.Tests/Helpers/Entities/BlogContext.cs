using System.Data.Entity;

namespace System.Linq.Dynamic.Tests.Helpers.Entities
{
    public class BlogContext : DbContext
    {
        public BlogContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}