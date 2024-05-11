using Microsoft.Extensions.Configuration;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Data.Repositories
{
    public class RegiaoRepository : BaseRepository<Regiao>, IRegiaoRepository
    {
        public RegiaoRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
