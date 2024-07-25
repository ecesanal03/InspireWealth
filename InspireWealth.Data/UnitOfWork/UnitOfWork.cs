using InspireWealth.Data.Entities;
using InspireWealth.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspireWealth.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IGenericRepository<T> GenericRepository<T>() where T : class, IEntity
        {
            if (!_repositories.Keys.Contains(typeof(T)))
            {
                var repository = new GenericRepository<T>(_context);
                _repositories.Add(typeof(T), repository);
            }

            var repo = _repositories[typeof(T)] as IGenericRepository<T>;
            if (repo == null)
            {
                throw new InvalidOperationException($"Repository for type {typeof(T)} is not registered.");
            }

            return repo;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
