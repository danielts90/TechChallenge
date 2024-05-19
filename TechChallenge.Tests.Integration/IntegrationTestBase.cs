using System.Data;
using System.Net.Http;
using System.Text.Json;

namespace TechChallenge.Tests.Integration
{
    public abstract class IntegrationTestBase : IClassFixture<CustomWebApplicationFactory<Program>>, IDisposable
    {
        protected readonly HttpClient _client;

        protected IntegrationTestBase(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        //public async Task<T> GetAsync<T>(string url)
        //{
        //    try
        //    {
        //        var response = await _client.GetAsync(url);
        //        response.EnsureSuccessStatusCode();
        //        string responseBody = await response.Content.ReadAsStringAsync();
        //        T result = JsonSerializer.Deserialize<T>(responseBody);
        //        return result;
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Console.WriteLine($"Request error: {e.Message}");
        //        throw;
        //    }
        //    catch (JsonException e)
        //    {
        //        Console.WriteLine($"Serialization error: {e.Message}");
        //        throw;
        //    }
        //}
    }

}
