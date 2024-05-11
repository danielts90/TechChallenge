using FluentValidation;
using TechChallenge.Business.Dtos;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Business.Services
{
    public class BaseService<TDto, TEntity> : IBaseService<TDto, TEntity> where TDto : DtoBase where TEntity : EntityBase
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task Delete(long id)
        {
            var existentEntity = await _repository.GetById(id);

            if (existentEntity is TEntity)
                await _repository.Delete(existentEntity);
            else
                throw new ArgumentException("Entidade não encontrada.");
        }

        public async Task<IEnumerable<TDto>> GetAll()
        {
            var result = await _repository.GetAll();
            return result.Select(entity => (TDto)entity);
        }

        public async Task<TDto> GetById(long id)
        {
            var result = await _repository.GetById(id);
            if (result is TEntity)
                return (TDto)result;
            return null;
        }

        public async Task<long> Insert(TDto dto)
        {
            var validations = dto.Validate();
            if (validations.IsValid)
                return await _repository.Insert((TEntity)dto);
            else
            {
                string errorMessage = string.Join(Environment.NewLine, validations.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errorMessage);
            }
        }

        public async Task Update(TDto dto)
        {
            var validations = dto.Validate();
            if (!validations.IsValid)
            {
                string errorMessage = string.Join(Environment.NewLine, validations.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errorMessage);
            }

            var existentEntity = await _repository.GetById(dto.Id);
            if (existentEntity is TEntity)
                await _repository.Update((TEntity)dto);
            else
                throw new ArgumentException("Entidade não encontrada.");
        }
    }
}

