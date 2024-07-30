using TechChallenge.Business.Dtos;
using TechChallenge.Business.Dtos.Complexos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Business.Services
{
    public class RegiaoService : BaseService<RegiaoDto, Regiao>, IRegiaoService
    {
        private readonly IRegiaoRepository _regiaoRepository;
        public RegiaoService(IRegiaoRepository repository) : base(repository)
        {
            _regiaoRepository = repository;
        }

        public async Task<RegiaoComDddDto> ObterRegiaoComDdd(long regiaoId)
        {
            var regiaoComDds = await _regiaoRepository.ObterRegiaoComDdds(regiaoId);
            return regiaoComDds;
        }
    }
}
