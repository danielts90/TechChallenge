using System.Net;
using System.Text;
using System.Text.Json;
using TechChallenge.Business.Dtos;

namespace TechChallenge.Tests.Integration
{
    public class RegiaoIntegrationTests : IntegrationTestBase
    {
        public RegiaoIntegrationTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Theory(DisplayName = "Check Regiao Get Endpoints")]
        [Trait("Regiao Integration", "Check Get Endpoints")]
        [InlineData("/regiao")]
        [InlineData("/regiao/1")]
        [InlineData("/regiao/regiao-com-ddds/1")]
        public async Task GetValues_ReturnsSuccessStatusCode(string endpoint)
        {
            var response = await _client.GetAsync(endpoint);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Regiao Post")]
        [Trait("Regiao Integration", "Insert")]
        public async Task Post_ReturnsSuccessStatusCode()
        {
            //Arrange
            RegiaoDto regiao = new() { Nome = "Regiao de Testes" };
            var json = JsonSerializer.Serialize(regiao);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            //Act
            var response = await _client.PostAsync("/Regiao", content);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Regiao Put")]
        [Trait("Regiao Integration", "Update")]
        public async Task Put_ReturnsSuccessStatusCode()
        {
            //Arrange
            RegiaoDto regiao = new() { Id = 1, Nome = "Regiao de Testes" };
            var json = JsonSerializer.Serialize(regiao);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            //Act
            var response = await _client.PutAsync($"/Regiao/{regiao.Id}", content);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Regiao Delete")]
        [Trait("Regiao Integration", "Delete")]
        public async Task Delete_ReturnsSuccessStatusCode()
        {
            //Arrange
            RegiaoDto regiao = new() { Id = 4, Nome = "Regiao de Testes" };


            //Act
            var response = await _client.DeleteAsync($"/Regiao/{regiao.Id}");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}