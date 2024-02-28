using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Testcontainers.CosmosDb;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NetflixApi.Infrastructure;
using Microsoft.Azure.Cosmos;
namespace NetflixApi.Application.IntegrationTests.Infrastructure;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly CosmosDbContainer _cosmosContainer = new CosmosDbBuilder()
        .WithImage("mcr.microsoft.com/cosmosdb/linux/azure-cosmos-emulator:latest")
        .Build();

    private string _connectionString;
    private string _databaseName;


    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<ApplicationDbContext>));

            services.AddDbContextFactory<ApplicationDbContext>((sp, opts) =>
            {

                opts.UseCosmos(_connectionString, _databaseName, (dbOptions) =>
                {
                    dbOptions.ConnectionMode(ConnectionMode.Direct);
                });
            });
        });
    }

    public async Task InitializeAsync()
    {
        await _cosmosContainer.StartAsync();

        // Get connection string and database name after container is started
        _connectionString = _cosmosContainer.GetConnectionString();
        _databaseName = "DevData"; // Set your desired database name here
    }

    public new async Task DisposeAsync()
    {
        await _cosmosContainer.StopAsync();
    }
}
