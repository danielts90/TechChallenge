using TechChallenge.Business.Dtos.Complexos;
using TechChallenge.Business.Entities;

namespace TechChallenge.Business.Interfaces
{
    public interface IDddRepository : IBaseRepository<Ddd> 
    {
        Task<DddComContatosDto> ObterDddComContatos(long dddId);
    }
}
