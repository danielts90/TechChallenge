using System.Data;

namespace TechChallenge.Tests.Integration
{
    public abstract class IntegrationTestBase : IClassFixture<CustomWebApplicationFactory<Program>>, IDisposable
    {
        protected readonly HttpClient _client;
        protected readonly IDbConnection _dbConnection;

        protected IntegrationTestBase(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }

}
