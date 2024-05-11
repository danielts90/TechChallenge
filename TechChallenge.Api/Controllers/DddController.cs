using TechChallenge.Business.Dtos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Api.Controllers
{
    public class DddController : BaseController<DddDto, Ddd>
    {
        public DddController(IDddService service) : base(service)
        {
        }
    }
}
