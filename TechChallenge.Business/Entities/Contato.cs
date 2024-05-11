using Dapper.Contrib.Extensions;
using TechChallenge.Business.Dtos;

namespace TechChallenge.Business.Entities
{
    [Table("contato")]
    public class Contato : EntityBase
    {
        public string? nome { get; set; }
        public string? telefone { get; set; }
        public string? email { get; set; }
        public long? ddd_Id { get; set; }
        protected override ContatoDto ToDto()
        {
            return new ContatoDto
            {
                Id = id,
                Nome = nome,
                Telefone = telefone,
                Email = email,
                DddId = ddd_Id,
            };
        }
    }
}
