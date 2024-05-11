using Microsoft.Extensions.Configuration;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Data.Repositories
{
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }

}
