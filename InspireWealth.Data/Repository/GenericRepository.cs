using InspireWealth.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InspireWealth.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }


        //Retrieves an entity by its id IF it belongs to the current user. 
        public virtual async Task<T> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("Invalid ID", nameof(id));
            }


            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                throw new KeyNotFoundException("Entity not found or you do not have the permision to update it.");
            }

            return entity;
        }

        //Retrieves all entities that belong to the current user.
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.ToListAsync();
        }

        //Adds a new entity and associates it with the current user.
        public virtual async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Invalid Entity", nameof(entity));
            }

            await _dbSet.AddAsync(entity);
        }

        //Updates an existing entity if it belongs to the current user.
        public virtual async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Invalid Entity", nameof(entity));
            }

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        // Deletes an entity if it belongs to the current user.
        public virtual async Task DeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("Invalid ID", nameof(id));
            }

            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
    }
}
