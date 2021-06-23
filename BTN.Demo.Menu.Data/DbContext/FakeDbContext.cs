using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Validation;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Data.DbContext
{
    /// <summary>
    /// Base Generic class for Fake DB Context
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FakeDbContext<T> : IFakeDbContext<T> where T : BaseEntity
    {
        private const string key = "<!!!ContextFor{0}WithKey{1}!!!>";
        private static ConcurrentDictionary<string, T> data = new ConcurrentDictionary<string, T>();

        ///<inheritdoc cref="IFakeDbContext{T}.Create(T)"/>
        public async Task Create(T entity)
        {
            entity.ValidateNotNull(nameof(entity));
            
            entity.Id = Guid.NewGuid();
            var key = BuildKey(entity.Id);
            
            
            if (data.TryAdd(key, entity))
            {
                return;
            }
            
            throw new InvalidOperationException($"There was an attempt to insert entity { entity.Id} but already exists.");                    
        }

        ///<inheritdoc cref="IFakeDbContext{T}.Update(T)"/>
        public async Task Update(T entity)
        {
            entity.ValidateNotNull(nameof(entity));

            var key = BuildKey(entity.Id);

            if (data.TryGetValue(key, out T result))
            {
                if (data.TryRemove(key, out _))
                {
                    await Create(entity);
                }
            }

            throw new InvalidOperationException($"There was an attempt to insert entity { entity.Id} but something went wrong");
        }

        ///<inheritdoc cref="IFakeDbContext{T}.GetAll"/>
        public async Task<IQueryable<T>> GetAll()
        {
            List<T> values = new List<T>();
            foreach(var item in data.Values)
            {
                if (item is T)
                {
                    values.Add(item);
                }
            }

            return values.AsQueryable();
        }

        ///<inheritdoc cref="IFakeDbContext{T}.Get(Guid)"/>
        public async Task<T> Get(Guid id)
        {
            var key = BuildKey(id);

            if (data.TryGetValue(key,out T result))
            {
                return result;
            }

            return null;
        }

        public string BuildKey(Guid Id)
        {
            return String.Format(key,typeof(T), Id);
        }

        ///<inheritdoc cref="IFakeDbContext{T}.Reset"/>
        public async Task Reset()
        {
            data = new ConcurrentDictionary<string, T>();
        }
    }
}
