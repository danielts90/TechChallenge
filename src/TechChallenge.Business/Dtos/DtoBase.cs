using FluentValidation.Results;
using TechChallenge.Business.Entities;

namespace TechChallenge.Business.Dtos
{
    public abstract class DtoBase
    {
        public long Id { get; set; }

        public static implicit operator EntityBase(DtoBase dto) => dto.ToEntity();

        protected abstract EntityBase ToEntity();

        public abstract ValidationResult Validate();
    }
}
