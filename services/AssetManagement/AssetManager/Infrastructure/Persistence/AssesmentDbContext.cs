using AssetManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Infrastructure.Persistence
{
    public class AssesmentDbContext: DbContext
    {
        public AssesmentDbContext(DbContextOptions<AssesmentDbContext> options) : base(options)
        {
        }

        public DbSet<Assesment> Assesments { get; set; }
        public DbSet<Contribution> Contributions { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assesment>().ToTable("Assesment");
            modelBuilder.Entity<Contribution>().ToTable("Contribution");
            modelBuilder.Entity<Currency>().ToTable("Currency");
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
