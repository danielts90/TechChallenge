using Microsoft.Extensions.Configuration;
using System.Data;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Data.Repositories
{
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(IDbConnection connection) : base(connection)
        {
        }
    }

}
