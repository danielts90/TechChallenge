using FluentValidation.Results;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Validators;

namespace TechChallenge.Business.Dtos
{
    public class DddDto : DtoBase
    {
        public string? Codigo { get; set; }
        public long? RegiaoId { get; set; }
        public override ValidationResult Validate()
        {
            var validator = new DddValidator();
            return validator.Validate(this);
        }

        protected override EntityBase ToEntity()
        {
            return new Ddd
            {
                id = Id,
                codigo = Codigo,
                regiao_id = RegiaoId
            };
        }
    }

}
