using Microsoft.Extensions.DependencyInjection;
using Skinet.Data.Repositories;
using Skinet.Domain.Interfaces;
namespace Skinet.CrossCutting.InversionOfControl;

public static class SqlServerRepositoryDependency
{
    public static void AddSqlServerRepositoryDependency(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductBrandRepository, ProductBrandRepository>();
        services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
        // Generic Repository
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}