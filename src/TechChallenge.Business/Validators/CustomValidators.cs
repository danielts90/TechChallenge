using FluentValidation;
using TechChallenge.Business.Util;

namespace TechChallenge.Business.Validators
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, string?> NotNullOrEmpty<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder.Must(value => !string.IsNullOrEmpty(value))
                              .WithMessage("Property cannot be null or empty.");
        }

        public static IRuleBuilderOptions<T, string?> IsPhoneNumber<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder.Must(telefone =>
            {
                if (telefone == null) return false;

                var regex = RegexHelper.DigitsRegex();
                return regex.IsMatch(telefone);
            });
        }
    }

}
