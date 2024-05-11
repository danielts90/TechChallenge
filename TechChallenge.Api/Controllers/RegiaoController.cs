using TechChallenge.Business.Dtos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Api.Controllers
{
    public class RegiaoController : BaseController<RegiaoDto, Regiao>
    {
        public RegiaoController(IRegiaoService service) : base(service)
        {
        }
    }
}
