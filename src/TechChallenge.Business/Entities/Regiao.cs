using System.ComponentModel.DataAnnotations.Schema;
using TechChallenge.Business.Dtos;

namespace TechChallenge.Business.Entities
{
    [Table("regiao")]
    public class Regiao : EntityBase
    {
        public string? nome { get; set; }
        protected override DtoBase ToDto()
        {
            return new RegiaoDto { Nome = nome, Id = id };
        }
    }
}
