using TechChallenge.Business.Dtos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Business.Services
{
    public class DddService : BaseService<DddDto, Ddd>, IDddService
    {
        public DddService(IDddRepository repository) : base(repository)
        {
        }
    }
}
