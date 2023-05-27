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
                var dbSeed = new DatabaseSeed();

                await dbSeed.SeedProducts(context);
            }
        }
    }
}
