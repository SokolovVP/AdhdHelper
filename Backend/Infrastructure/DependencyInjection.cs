using Application.Abstractions;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AdhdHelperDbContext>(options =>
        {
            options.UseNpgsql("DefaultConnection");
        });

        services.AddScoped<IChallengeRepository, ChallengeRepository>();
        services.AddScoped<IChallengeReadOnlyRepository, ChallengeReadOnlyRepository>();

        return services;
    }
}