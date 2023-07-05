using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Infrastructure.Persistence
{
    public static class PersistenceExtensions
    {
        public static void ApplyDbMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AssesmentDbContext>();
                context.Database.Migrate();
            }
        }

        public async static void SeedDatabaseInitialization(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AssesmentDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var dbSeed = new DatabaseSeed();

                await dbSeed.SeedProducts(context);
                await dbSeed.SeedUsers(userManager, roleManager);
            }
        }
    }
}
