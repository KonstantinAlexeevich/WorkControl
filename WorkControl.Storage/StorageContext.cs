using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkControl.Storage.Abstractions;
using WorkControl.Storage.Configurations;

namespace WorkControl.Storage
{
    public class StorageContext : IdentityDbContext
    {
        public StorageContext(DbContextOptions<StorageContext> options)
            : base(options)
        {
        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentWork> DocumentWorks { get; set; }
        public DbSet<Work> Works { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentWorkConfiguration());
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}