using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Extensions.ConfigureServices;

public static class AddDatabaseExtension
{
    public static IServiceCollection AddDatabase<DataContext, UnitOfWork>(this IServiceCollection services,
        string connectionString)
        where DataContext : DbContext, UnitOfWork where UnitOfWork : class
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<DbContext, DataContext>();
        services.AddScoped<UnitOfWork>(provider => provider.GetService<DataContext>()!);

        return services;
    }
}