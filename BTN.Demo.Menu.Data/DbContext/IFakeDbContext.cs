using BTN.Demo.Menu.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Data.DbContext
{
    /// <summary>
    /// Interface for Fake DbContexts
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFakeDbContext<T> where T : BaseEntity
    {
        /// <summary>
        /// Persists a new instance of an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Create(T entity);

        /// <summary>
        /// Updates a persisted entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Update(T entity);

        /// <summary>
        /// Retrieves all entities
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<T>> GetAll();

        /// <summary>
        /// Retrieves the entity with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> Get(Guid id);

        /// <summary>
        /// Resets data source
        /// </summary>
        /// <returns></returns>
        Task Reset();
    }
}
