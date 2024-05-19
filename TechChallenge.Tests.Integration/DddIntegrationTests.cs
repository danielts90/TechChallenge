using System.Net;

namespace TechChallenge.Tests.Integration
{
    public class DddIntegrationTests : IntegrationTestBase
    {
        public DddIntegrationTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact(DisplayName = "DDD GetAll")]
        [Trait("DDD Integration", "GetAll")]
        public async Task GetValues_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/Ddd");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}