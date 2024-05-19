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
            builder.ConfigureServices(async services =>
            {
                services.AddScoped<IDbConnection>(sp =>
                    new NpgsqlConnection("Host=localhost;Port=5432;Username=testuser;Password=102030;Database=testdb;Include Error Detail=true"));
                await SetupDatabase(services);
            });

            return base.CreateHost(builder);
        }

        private static async Task SetupDatabase(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            using var db = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IDbConnection>();
            await ExecuteSqlScriptAsync(db, "Setup/setup.sql");
        }

        protected static async Task ExecuteSqlScriptAsync(IDbConnection? connection, string scriptPath)
        {
            var script = File.ReadAllText(scriptPath);
            await connection.ExecuteAsync(script);
        }
    }

}