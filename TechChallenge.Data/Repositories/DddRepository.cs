using Microsoft.Extensions.Configuration;
using System.Data;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Data.Repositories
{
    public class DddRepository : BaseRepository<Ddd>, IDddRepository
    {
        public DddRepository(IDbConnection connection) : base(connection)
        {
        }
    }
}
