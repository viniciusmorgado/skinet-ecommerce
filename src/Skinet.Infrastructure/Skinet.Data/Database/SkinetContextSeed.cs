using Skinet.Domain.Entities;
using Skinet.Domain.Exceptions;
using System.Text.Json;

namespace Skinet.Data.Database;

public class SkinetContextSeed
{
    public static async Task SeedAsync(SkinetContext context
                                     , ILoggerFactory loggerFactory)
    {
        try
        {
            #region Products Brands
            if (!context.ProductBrands.Any())
            {
                string? brandsData = File.ReadAllText("C:/Users/vinic/source/Repos/skinet-ecommerce/src/Skinet.Infrastructure/Skinet.Data/SeedData/brands.json");
                List<ProductBrand>? brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                foreach (ProductBrand brand in brands)
                {
                    context.ProductBrands.Add(brand);
                }
                await context.SaveChangesAsync();
            }
            #endregion

            //#region Product Type
            //if (!context.ProductTypes.Any())
            //{
            //    string? typesData = File.ReadAllText("C:/Users/vinic/source/Repos/skinet-ecommerce/src/Skinet.Infrastructure/Skinet.Data/SeedData/types.json");
            //    List<ProductType>? types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
            //    if (types is not null)
            //    {
            //        foreach (ProductType type in types)
            //        {
            //            if (type is not null)
            //            {
            //                context.ProductTypes.Add(type);
            //            }
            //            throw new SeedDataException("The seed data for product type is null.");
            //        }
            //        await context.SaveChangesAsync();
            //    }
            //    throw new SeedDataException("The seed data for product type is null.");
            //}
            //#endregion

            //#region Products
            //if (!context.Products.Any())
            //{
            //    string? productsData = File.ReadAllText("C:/Users/vinic/source/Repos/skinet-ecommerce/src/Skinet.Infrastructure/Skinet.Data/SeedData/products.json");
            //    List<Product>? products = JsonSerializer.Deserialize<List<Product>>(productsData);
            //    if (products is not null)
            //    {
            //        foreach (Product product in products)
            //        {
            //            if (product is not null)
            //            {
            //                context.Products.Add(product);
            //            }
            //            throw new SeedDataException("The seed data for products is null.");
            //        }
            //        await context.SaveChangesAsync();
            //    }
            //    throw new SeedDataException("The seed data for products is null.");
            //}
            //#endregion
        }
        catch (SeedDataException ex)
        {
            var logger = loggerFactory.CreateLogger<SkinetContextSeed>();
            logger.LogError(ex.Message);
            throw new SeedDataException("The seed data has failed to populate the database");
        }
    }
}