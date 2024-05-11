using Microsoft.Extensions.Configuration;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Data.Repositories
{
    public class DddRepository : BaseRepository<Ddd>, IDddRepository
    {
        public DddRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
