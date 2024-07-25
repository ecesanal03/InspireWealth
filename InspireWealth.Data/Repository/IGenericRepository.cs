using InspireWealth.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace InspireWealth.Data.Repository
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task<T> GetByIdAsync(string id); //Retrieves an entity by its id IF it belongs to the current user.
        Task<IEnumerable<T>> GetAllAsync(); //Retrieves all entities that belong to the current user..
        Task<IEnumerable<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity); //Adds a new entity and associates it with the current user.
        Task UpdateAsync(T entity); //Updates an existing entity if it belongs to the current user.
        Task DeleteAsync(string id); // Deletes an entity if it belongs to the current user.
    }
}
