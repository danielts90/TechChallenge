using System.Net;
using System.Text;
using System.Text.Json;
using TechChallenge.Business.Dtos;
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

        [Fact(DisplayName = "Contato Post")]
        [Trait("Contato Integration", "Insert")]
        public async Task Post_ReturnsSuccessStatusCode()
        {
            //Arrange
            ContatoDto contato = new() { Nome = "Contato Teste", DddId = 1, Email = "novo@contato.com", Telefone = "123456789" };
            var json = JsonSerializer.Serialize(contato);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            //Act
            var response = await _client.PostAsync("/contato", content);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Contato Put")]
        [Trait("Contato Integration", "Update")]
        public async Task Put_ReturnsSuccessStatusCode()
        {
            //Arrange
            ContatoDto contato = new() { Id = 1, Nome = "Contato de Testes", Email = "contato@deteste.com", DddId = 1, Telefone = "123456789" };
            var json = JsonSerializer.Serialize(contato);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            //Act
            var response = await _client.PutAsync($"/contato/{contato.Id}", content);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Contato Delete")]
        [Trait("Contato Integration", "Delete")]
        public async Task Delete_ReturnsSuccessStatusCode()
        {
            //Arrange
            ContatoDto contato = new() { Id = 3 };


            //Act
            var response = await _client.DeleteAsync($"/contato/{contato.Id}");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}