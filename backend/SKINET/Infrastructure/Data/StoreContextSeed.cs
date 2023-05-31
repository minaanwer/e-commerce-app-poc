using Core.Entities;
using System.Text.Json;
 
namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if(!context.ProductBrands.Any())
            {
                var brandData = File.ReadAllText("../InfraStructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                context.ProductBrands.AddRange(brands);
            }
            if (!context.ProductTypes.Any())
            {
                var productTypeData = File.ReadAllText("../InfraStructure/Data/SeedData/types.json");
                var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypeData);
                context.ProductTypes.AddRange(productTypes);
            }

            if (!context.Products.Any())
            {
                var productData = File.ReadAllText("../InfraStructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize< List<Product>>(productData);
                context.Products.AddRange(products); 
            }

            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }

        }


    }
}
