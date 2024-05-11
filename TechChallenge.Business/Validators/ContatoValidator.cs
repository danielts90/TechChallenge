using FluentValidation;
using System.Text.RegularExpressions;
using TechChallenge.Business.Dtos;

namespace TechChallenge.Business.Validators
{
    public class ContatoValidator : AbstractValidator<ContatoDto>
    {
        public ContatoValidator() 
        {
            RuleFor(o => o.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Obrigatório informar o nome do contato.");

            RuleFor(o => o.Telefone)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo telefone é obrigatório")
                .Must(BePhoneNumber).WithMessage("O telefone inválido, o número do telefone deve ter 8 ou 9 dígitos.");

            RuleFor(o => o.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo e-mail é obrigatório.")
                .EmailAddress(mode: FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("E-mail inválido.");

            RuleFor(o => o.DddId)
                .NotNull().WithMessage("O ddd é obrigatório.");
        }

        private bool BePhoneNumber(string telefone)
        {
            var regex = new Regex(@"^\d{8,9}$");
            return regex.IsMatch(telefone);
        }
    }
}
