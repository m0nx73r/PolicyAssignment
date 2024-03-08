using Microsoft.EntityFrameworkCore;
using PolicyAssignment.DAL.Entities;
using PolicyAssignment.DAL.Repositories.Implemented;

namespace PolicyAssignment.DAL.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DocumentTemplate> DocumentTemplates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
