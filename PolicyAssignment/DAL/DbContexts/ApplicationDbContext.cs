using Microsoft.EntityFrameworkCore;
using PolicyAssignment.DAL.Entities;

namespace PolicyAssignment.DAL.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DocumentTemplates> DocumentTemplates { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
