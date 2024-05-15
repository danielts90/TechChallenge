using Dapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System.Data;
using System.Net;

namespace TechChallenge.Tests.Integration
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IDbConnection>((sp) =>
                    new NpgsqlConnection("Host=localhost;Port=5432;Username=testuser;Password=102030;Database=testdb"));
            });

            return base.CreateHost(builder);
        }
    }

    public class IntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>, IDisposable
    {
        private readonly HttpClient _client;
        private readonly IDbConnection _dbConnection;

        public IntegrationTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            _dbConnection = new NpgsqlConnection("Host=localhost;Port=5432;Username=testuser;Password=102030;Database=testdb");

            _dbConnection.Open();
            ExecuteSqlScript(_dbConnection, "Setup\\setup.sql");
        }

        private void ExecuteSqlScript(IDbConnection dbConnection, string scriptPath)
        {
            var script = File.ReadAllText(scriptPath);
            dbConnection.Execute(script);
        }

        [Theory]
        [InlineData("/Regiao")]
        public async Task GetValues_ReturnsSuccessStatusCode(string route)
        {
            var response = await _client.GetAsync(route);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public void Dispose()
        {
            _dbConnection?.Dispose();
        }
    }
}