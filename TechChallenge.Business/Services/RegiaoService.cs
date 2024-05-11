using TechChallenge.Business.Dtos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Business.Services
{
    public class RegiaoService : BaseService<RegiaoDto, Regiao>, IRegiaoService
    {
        public RegiaoService(IRegiaoRepository repository) : base(repository)
        {
        }
    }
}
