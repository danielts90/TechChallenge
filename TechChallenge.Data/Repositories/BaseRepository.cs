using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using TechChallenge.Business.Entities;
using TechChallenge.Business.Interfaces;

namespace TechChallenge.Data.Repositories
{
    public abstract class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : EntityBase
    {
        protected readonly IDbConnection _db;

        protected BaseRepository(IConfiguration configuration)
        {
            _db = new NpgsqlConnection(configuration.GetConnectionString("TechChallengeDb"));
        }

        public async Task<long> Insert(T entity)
        {
            entity.created_at = DateTime.Now;
            return await _db.InsertAsync(entity);
        }

        public async Task Update(T entity)
        {
            await _db.UpdateAsync(entity);
        }

        public async Task Delete(T entity)
        {
            await _db.DeleteAsync(entity);
        }

        public async Task<T> GetById(long id)
        {
            return await _db.GetAsync<T>(id);

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.GetAllAsync<T>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                }
            }
        }
    }
}
