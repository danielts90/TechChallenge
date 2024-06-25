using TechChallenge.Business.Dtos;
using TechChallenge.Business.Dtos.Complexos;
using TechChallenge.Business.Entities;

namespace TechChallenge.Business.Interfaces
{
    public interface IDddService : IBaseService<DddDto, Ddd>
    {
        Task<DddComContatosDto> ObterDddsComContato(long dddId);
    }
}
