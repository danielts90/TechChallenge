using System.Net;
using System.Text;
using System.Text.Json;
using TechChallenge.Business.Dtos;
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
        [InlineData("/ddd/ddd-com-contato/999")]
        public async Task GetValues_ReturnsSuccessStatusCode(string endpoint)
        {
            var response = await _client.GetAsync(endpoint);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "DDD Post")]
        [Trait("DDD Integration", "Insert")]
        public async Task Post_ReturnsSuccessStatusCode()
        {
            //Arrange
            DddDto ddd = new() { Codigo = "33", RegiaoId = 1 };
            var json = JsonSerializer.Serialize(ddd);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            //Act
            var response = await _client.PostAsync("/DDD", content);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "DDD Put")]
        [Trait("DDD Integration", "Update")]
        public async Task Put_ReturnsSuccessStatusCode()
        {
            //Arrange
            DddDto ddd = new() { Id = 1, Codigo = "35", RegiaoId = 1 };
            var json = JsonSerializer.Serialize(ddd);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            //Act
            var response = await _client.PutAsync($"/DDD/{ddd.Id}", content);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "DDD Delete")]
        [Trait("DDD Integration", "Delete")]
        public async Task Delete_ReturnsSuccessStatusCode()
        {
            //Arrange
            DddDto ddd = new() { Id = 4 };


            //Act
            var response = await _client.DeleteAsync($"/DDD/{ddd.Id}");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}