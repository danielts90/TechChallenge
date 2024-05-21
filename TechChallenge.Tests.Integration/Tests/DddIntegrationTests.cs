using System.Net;
using TechChallenge.Tests.Integration.Fixtures;

namespace TechChallenge.Tests.Integration.Tests
{
    [Collection("Database collection")]

    public class DddIntegrationTests : IntegrationTestBase
    {
        private readonly DatabaseFixture _databaseFixture;
        public DddIntegrationTests(CustomWebApplicationFactory<Program> factory, DatabaseFixture databaseFixture) : base(factory)
        {
            _databaseFixture = databaseFixture;
        }

        [Theory(DisplayName = "Check DDD Get Endpoints")]
        [Trait("DDD Integration", "Check Get Endpoints")]
        [InlineData("/ddd")]
        [InlineData("/ddd/1")]
        [InlineData("/ddd/ddd-com-contato/1")]
        public async Task GetValues_ReturnsSuccessStatusCode(string endpoint)
        {
            var response = await _client.GetAsync(endpoint);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}