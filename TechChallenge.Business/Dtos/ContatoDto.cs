using FluentValidation.Results;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Validators;

namespace TechChallenge.Business.Dtos
{
    public class ContatoDto : DtoBase
    {
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public long? DddId { get; set; }

        public override ValidationResult Validate()
        {
            var validator = new ContatoValidator();
            return validator.Validate(this);
        }

        protected override EntityBase ToEntity()
        {
            return new Contato
            {
                nome = Nome,
                email = Email,
                telefone = Telefone,
                ddd_Id = DddId,
            };
        }
    }
}
