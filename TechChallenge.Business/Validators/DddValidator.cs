﻿using FluentValidation;
using TechChallenge.Business.Dtos;

namespace TechChallenge.Business.Validators
{
    public class DddValidator : AbstractValidator<DddDto>
    {
        public DddValidator() 
        {
            RuleFor(o => o.Codigo)
                .NotNullOrEmpty()
                .WithMessage("O código do DDD é obrigatório.")
                .Length(2).WithMessage("O DDD deve ter dois dígitos.");
        }
    }
}
