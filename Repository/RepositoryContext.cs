using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repository.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LaboratoryConfiguration());
            modelBuilder.ApplyConfiguration(new AssayConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

        }

        public DbSet<Laboratory>? Laboratories { get; set; }
        public DbSet<Assay>? Assays { get; set; }
    }
}
