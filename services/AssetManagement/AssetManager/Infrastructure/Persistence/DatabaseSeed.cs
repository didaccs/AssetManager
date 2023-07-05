using AssetManager.Domain;
using Microsoft.AspNetCore.Identity;

namespace AssetManager.Infrastructure.Persistence
{
    public class DatabaseSeed
    {
        public async Task SeedProducts(AssesmentDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(new List<Product>
                    {
                        new Product
                        {
                            Category = "Cash",
                            Name = "MyInvestor"
                        },
                        new Product
                        {
                            Category = "Cash",
                            Name = "Evo Banc"
                        },
                        new Product
                        {
                            Category = "Indexs",
                            Name = "My Investor"
                        },
                        new Product
                        {
                            Category = "Crowdfunding",
                            Name = "CrowdCube"
                        },
                        new Product
                        {
                            Category = "Crypto",
                            Name = "Crypto.com"
                        },
                        new Product
                        {
                            Category = "Crypto",
                            Name = "Binance"
                        }
                    });

                await context.SaveChangesAsync();                
            }
        }

        public async Task SeedUsers(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var testUser = await userManager.FindByNameAsync("testUser");
            if (testUser is null)
                await userManager.CreateAsync(new IdentityUser{ UserName = "testUser" }, "Passw0rd.1234");

            var otherUser = await userManager.FindByNameAsync("otherUser");
            if (otherUser is null)
                await userManager.CreateAsync(new IdentityUser { UserName = "otherUser" }, "Passw0rd.1234");

            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole is null)
            {
                await roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Admin"
                });
                await userManager.AddToRoleAsync(testUser, "Admin");            
            }
        }
    }
}
