using ForumUnifeso.src.API.Model;
using Microsoft.EntityFrameworkCore;

namespace ForumUnifeso.src.API.Base.Context
{
    public class PrincipalDbContext : DbContext
    {
        public PrincipalDbContext(DbContextOptions<PrincipalDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Post { get; set; } = null!;
        public DbSet<Person> Person { get; set; } = null!;
        public DbSet<ThreadForum> ThreadForum { get; set; } = null!;
    }
}
