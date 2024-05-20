using System.Net;

namespace TechChallenge.Tests.Integration
{
    public class DddIntegrationTests : IntegrationTestBase
    {
        public DddIntegrationTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
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