using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TechChallenge.Tests.Integration.Config
{
    public class TechChallengeFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseStartup<TProgram>();
            builder.UseEnvironment("Testing");
        }
    }
}
