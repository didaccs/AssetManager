using AssetManager.Application.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AssetManager.Application.Services;

namespace AssetManager.Application.Infrastructure.Persistence;

public class AssesmentDbContext: IdentityDbContext<IdentityUser>
{
    private readonly CurrentUser _user;

    public AssesmentDbContext(DbContextOptions<AssesmentDbContext> options, ICurrentUserService currentUserService) : base(options)
    {
        _user = currentUserService.User;
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

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _user.Id;
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _user.Id;
                    entry.Entity.LastModifiedByAt = DateTime.UtcNow;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
