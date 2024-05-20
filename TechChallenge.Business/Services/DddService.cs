using TechChallenge.Business.Dtos;
using TechChallenge.Business.Dtos.Complexos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Business.Services
{
    public class DddService : BaseService<DddDto, Ddd>, IDddService
    {
        private readonly IDddRepository _dddRepository;
        public DddService(IDddRepository repository) : base(repository)
        {
            _dddRepository = repository;
        }

        public async Task<DddComContatosDto> ObterDddsComContato(long dddId)
        {
            var dddComContatos = await _dddRepository.GetDddComContatos(dddId);
            return dddComContatos;
        }
    }
}
