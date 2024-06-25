using TechChallenge.Business.Dtos;
using TechChallenge.Business.Dtos.Complexos;
using TechChallenge.Business.Entities;

namespace TechChallenge.Business.Interfaces
{
    public interface IRegiaoService : IBaseService<RegiaoDto, Regiao>
    {
        Task<RegiaoComDddDto> ObterRegiaoComDdd(long regiaoId);
    }
}
