using OnePieceApi.Entities;

namespace OnePieceApi.DI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        return services;
    }
}