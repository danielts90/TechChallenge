using TechChallenge.Business.Dtos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Business.Services
{
    public class ContatoService : BaseService<ContatoDto, Contato>, IContatoService
    {
        public ContatoService(IContatoRepository repository) : base(repository)
        {
        }
    }
}
