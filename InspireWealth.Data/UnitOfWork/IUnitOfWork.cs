using InspireWealth.Data.Entities;
using InspireWealth.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspireWealth.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GenericRepository<T>() where T : class, IEntity;
        Task<int> SaveChangesAsync();
    }
}
