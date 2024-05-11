using TechChallenge.Business.Dtos;
using TechChallenge.Business.Entities;

namespace TechChallenge.Business.Interfaces
{
    public interface IBaseService<TDto, TEntity> where TDto : DtoBase where TEntity : EntityBase
    {
        Task<long> Insert(TDto dto);
        Task Update(TDto dto);
        Task Delete(long id);
        Task<TDto> GetById(long id);
        Task<IEnumerable<TDto>> GetAll();
    }
}
