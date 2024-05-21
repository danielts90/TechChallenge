using Dapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System.Data;

namespace TechChallenge.Tests.Integration.Fixtures
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IDbConnection>(sp =>
                    new NpgsqlConnection("Host=localhost;Port=5432;Username=testuser;Password=102030;Database=testdb;Include Error Detail=true"));
            });

            return base.CreateHost(builder);
        }
    }

}