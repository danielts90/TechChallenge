using TechChallenge.Business.Dtos;

namespace TechChallenge.Business.Entities
{
    public class Regiao : EntityBase
    {
        public string? Nome { get; set; }
        protected override DtoBase ToDto()
        {
            return new RegiaoDto { Nome = Nome, Id = Id };
        }
    }
}
