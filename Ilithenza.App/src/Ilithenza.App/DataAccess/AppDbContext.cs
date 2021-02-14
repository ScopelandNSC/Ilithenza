using Ilithenza.App.DataAccess.ContextConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Ilithenza.App.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Class> Classes { get; set; }

        public DbSet<ClassPath> ClassPaths { get; set; }

        public DbSet<ClassPathNode> ClassPathNodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
        }
    }
}
