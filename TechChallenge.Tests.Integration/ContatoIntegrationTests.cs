using System.Net;

namespace TechChallenge.Tests.Integration
{
    public class ContatoIntegrationTests : IntegrationTestBase
    {
        public ContatoIntegrationTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact(DisplayName = "Contato GetAll")]
        [Trait("Contato Integration", "GetAll")]
        public async Task GetValues_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/Contato");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}