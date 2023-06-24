using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LaboratoryConfiguration());
            modelBuilder.ApplyConfiguration(new AssayConfiguration());
        }

        public DbSet<Laboratory>? Laboratories { get; set; }
        public DbSet<Assay>? Assays { get; set; }
    }
}
