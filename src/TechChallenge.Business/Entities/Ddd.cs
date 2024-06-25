using Dapper.Contrib.Extensions;
using TechChallenge.Business.Dtos;

namespace TechChallenge.Business.Entities
{
    [Table("ddd")]
    public class Ddd : EntityBase
    {
        public string? codigo { get; set; }
        public long? regiao_id { get; set; }
        protected override DddDto ToDto()
        {
            return new DddDto
            {
                Id = id,
                RegiaoId = regiao_id,
                Codigo = codigo
            };
        }
    }
}
