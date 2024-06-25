using TechChallenge.Business.Dtos.Complexos;
using TechChallenge.Business.Entities;

namespace TechChallenge.Business.Interfaces
{
    public interface IRegiaoRepository : IBaseRepository<Regiao>
    {
        Task<RegiaoComDddDto> ObterRegiaoComDdds(long regiaoId);
    }
}
