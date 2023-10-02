namespace Infrastructure;

using Application.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IPropertyRepo, PropertyRepo>()
                .AddTransient<IImageRepo, ImageRepo>()
                .AddDbContext<ApplicationDbContext>(options =>
                                                    {
                                                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                                                    });

        return services;
    }
}
