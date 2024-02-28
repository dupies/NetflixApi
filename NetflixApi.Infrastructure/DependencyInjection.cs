using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Movies;
using NetflixApi.Domain.Movies.MovieHistories;
using NetflixApi.Domain.TVShows;
using NetflixApi.Domain.Users;
using NetflixApi.Infrastructure.Data;
using NetflixApi.Infrastructure.Repositories;

namespace NetflixApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var dbSettings = new CosmosDbSettings()
        {
            ConnectionString = configuration.GetConnectionString("ConnectionString")!,
            Database = configuration.GetConnectionString("Database")!
        };

        services.AddSingleton(dbSettings);

        services.AddDbContextFactory<ApplicationDbContext>((sp, opts) =>
        {
            opts.UseCosmos(dbSettings.ConnectionString, dbSettings.Database, (dbOptions) =>
            {
                dbOptions.ConnectionMode(ConnectionMode.Direct);
            });
        });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ITVShowRespository, TVShowRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMovieHistoryRepository, MovieHistoryRepository>();

        return services;
    }
}