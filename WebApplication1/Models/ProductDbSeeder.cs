using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ProductDbSeeder
    {
        public static void Initialize(ProductDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any flowers.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            context.Products.AddRange(
                new Product
                {
                    Name = "GPU",
                    Description = "RTX 2080 MSI DUKE",
                    Category = "Video processing",
                    Price = 300
                },
                new Product
                {
                    Name = "CPU",
                    Description = "AMD Ryzen 2700x",
                    Category = "Processing",
                    Price = 150
                }
            );
            context.SaveChanges();
        }

    }
}
