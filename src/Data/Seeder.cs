using practica1.src.Data;
using practica1.src.Models;

namespace EjemploApiC1.src.Models.Data
{
    public static class Seeder
    {
        public static async Task Seed(DataContext context)
        {
            if (context.Products.Any() || context.Categories.Any())
                return;

            var categoriesList = new List<Category>
            {
                new Category { Id = 1, CategoryName = "POLERAS"},
                new Category { Id = 2, CategoryName = "PANTALONES"},
                new Category { Id = 3, CategoryName = "SOMBREROS"}
            };

            await context.Categories.AddRangeAsync(categoriesList);
            await context.SaveChangesAsync();
            

            var categories = context.Categories.ToList();
            var random = new Random();

            for (int i = 0; i < 1000; i++)
            {
                var randomCategory = categories[random.Next(0, categories.Count)];
                var product = new Product
                {
                    Code = $"P{i}",
                    Name = $"Product {i}",
                    CategoryId = randomCategory.Id,
                    Category = randomCategory,
                    Stock = random.Next(1, 100)
                };

                await context.Products.AddAsync(product);
            }

            await context.SaveChangesAsync();
        }
    }
}