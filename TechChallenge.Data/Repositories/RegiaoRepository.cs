using Microsoft.Extensions.Configuration;
using System.Data;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Data.Repositories
{
    public class RegiaoRepository : BaseRepository<Regiao>, IRegiaoRepository
    {
        public RegiaoRepository(IDbConnection connection) : base(connection)
        {
        }
    }
}
