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

        [Fact(DisplayName = "Regiao GetAll")]
        [Trait("Regiao Integration", "GetAll")]
        public async Task GetValues_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/Regiao");

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
            var json = JsonSerializer.Serialize(regiao);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            //Act
            var response = await _client.DeleteAsync($"/Regiao/{regiao.Id}");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}