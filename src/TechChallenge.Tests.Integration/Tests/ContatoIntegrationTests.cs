using System.Net;
using TechChallenge.Tests.Integration.Fixtures;

namespace TechChallenge.Tests.Integration.Tests
{
    [Collection("Database collection")]
    public class ContatoIntegrationTests : IntegrationTestBase
    {
        private readonly DatabaseFixture _databaseFixture;
        public ContatoIntegrationTests(CustomWebApplicationFactory<Program> factory, DatabaseFixture databaseFixture) : base(factory)
        {
            _databaseFixture = databaseFixture;
        }

        [Theory(DisplayName = "Check Contato Get Endpoints")]
        [Trait("Contato Integration", "Check Get Endpoints")]
        [InlineData("/contato")]
        [InlineData("/contato/1")]
        public async Task GetValues_ReturnsSuccessStatusCode(string endpoint)
        {
            var response = await _client.GetAsync(endpoint);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}