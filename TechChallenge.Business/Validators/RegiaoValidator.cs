using FluentValidation;
using TechChallenge.Business.Dtos;

namespace TechChallenge.Business.Validators
{
    public class RegiaoValidator : AbstractValidator<RegiaoDto>
    {
        public RegiaoValidator()
        {
            RuleFor(o => o.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Região deve ser informada.");
        }
    }
}
