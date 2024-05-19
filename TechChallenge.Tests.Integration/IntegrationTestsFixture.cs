using Dapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System.Data;

namespace TechChallenge.Tests.Integration
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IDbConnection>(sp => new NpgsqlConnection("Host=localhost;Port=5432;Username=testuser;Password=102030;Database=testdb"));
                SetupDatabase(services).Wait();

            });

            return base.CreateHost(builder);
        }

        private static async Task SetupDatabase(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            using var db = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IDbConnection>();
            ExecuteSqlScript(db, "Setup/setup.sql");

        }

        protected static void ExecuteSqlScript(IDbConnection? connection, string scriptPath)
        {
            var script = File.ReadAllText(scriptPath);
            connection.Execute(script);
        }
    }
}