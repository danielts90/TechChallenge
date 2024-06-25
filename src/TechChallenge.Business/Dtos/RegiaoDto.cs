using FluentValidation.Results;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Validators;

namespace TechChallenge.Business.Dtos
{
    public class RegiaoDto : DtoBase
    {
        public string? Nome { get; set; }

        public override ValidationResult Validate()
        {
            var validator = new RegiaoValidator();
            return validator.Validate(this);
        }

        protected override EntityBase ToEntity()
        {
            return new Regiao { 
                nome = Nome ,
                id = Id 
            };
        }
    }
}
