using System.ComponentModel.DataAnnotations.Schema;
using TechChallenge.Business.Dtos;

namespace TechChallenge.Business.Entities
{
    [Table("regiao")]
    public class Regiao : EntityBase
    {
        public string? Nome { get; set; }
        protected override DtoBase ToDto()
        {
            return new RegiaoDto { Nome = Nome, Id = Id };
        }
    }
}
