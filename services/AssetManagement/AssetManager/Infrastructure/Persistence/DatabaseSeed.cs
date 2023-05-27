using AssetManager.Domain;
using Microsoft.EntityFrameworkCore;

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
    }
}
