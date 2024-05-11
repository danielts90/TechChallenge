using TechChallenge.Business.Entities;

namespace TechChallenge.Business.Interfaces
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        Task<long> Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetById(long id);
        Task<IEnumerable<T>> GetAll();
    }
}
