using TechChallenge.Business.Interfaces;
using TechChallenge.Business.Services;
using TechChallenge.Data.Repositories;

namespace TechChallenge.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencyInjection(this IServiceCollection service)
        {
            service.AddScoped<IRegiaoRepository, RegiaoRepository>();
            service.AddScoped<IDddRepository, DddRepository>();
            service.AddScoped<IContatoRepository, ContatoRepository>();
            
            service.AddScoped<IRegiaoService, RegiaoService>();
            service.AddScoped<IDddService, DddService>();
            service.AddScoped<IContatoService, ContatoService>();
        }
    }
}
