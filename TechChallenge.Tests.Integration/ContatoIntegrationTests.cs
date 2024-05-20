using System.Net;

namespace TechChallenge.Tests.Integration
{
    public class ContatoIntegrationTests : IntegrationTestBase
    {
        public ContatoIntegrationTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
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