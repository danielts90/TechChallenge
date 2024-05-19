using FluentValidation;

namespace TechChallenge.Business.Validators
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, string> NotNullOrEmpty<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(value => !string.IsNullOrEmpty(value))
                              .WithMessage("Property cannot be null or empty.");
        }
    }

}
