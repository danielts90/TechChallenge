using FluentValidation;
using TechChallenge.Business.Dtos;
using TechChallenge.Business.Util;

namespace TechChallenge.Business.Validators
{
    public class ContatoValidator : AbstractValidator<ContatoDto>
    {
        public ContatoValidator() 
        {
            RuleFor(o => o.Nome)
                .NotNullOrEmpty()
                .WithMessage("Obrigatório informar o nome do contato.");

            RuleFor(o => o.Telefone)
                .NotNullOrEmpty()
                .WithMessage("O campo telefone é obrigatório")
                .IsPhoneNumber().WithMessage("O telefone inválido, o número do telefone deve ter 8 ou 9 dígitos.");

            RuleFor(o => o.Email)
                .NotNullOrEmpty()
                .WithMessage("O campo e-mail é obrigatório.")
                .EmailAddress(mode: FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("E-mail inválido.");

            RuleFor(o => o.DddId)
                .NotNull().WithMessage("O ddd é obrigatório.");
        }
    }
}
