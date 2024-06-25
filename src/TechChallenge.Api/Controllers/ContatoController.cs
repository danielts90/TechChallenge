using TechChallenge.Business.Dtos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Api.Controllers
{
    public class ContatoController : BaseController<ContatoDto, Contato>
    {
        public ContatoController(IContatoService service) : base(service)
        {
        }
    }
}
