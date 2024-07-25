using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspireWealth.Services.DTOs;

namespace InspireWealth.Services.Interfaces
{
    public interface IPortfolioTransactionService
    {
        Task<PortfolioTransactionDTO> GetPortfolioTransactionByIdAsync(string id);
        Task<IEnumerable<PortfolioTransactionDTO>> GetAllPortfolioTransactionsAsync();
        Task AddPortfolioTransactionAsync(PortfolioTransactionDTO portfolioTransactionDto);
        Task UpdatePortfolioTransactionAsync(PortfolioTransactionDTO portfolioTransactionDto);
        Task DeletePortfolioTransactionAsync(string id);
    }
}

//Task<T> GetByIdAsync(string id); //Retrieves an entity by its id IF it belongs to the current user.
//Task<IEnumerable<T>> GetAllAsync(); //Retrieves all entities that belong to the current user..
//Task<IEnumerable<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
//Task AddAsync(T entity); //Adds a new entity and associates it with the current user.
//Task UpdateAsync(T entity); //Updates an existing entity if it belongs to the current user.
//Task DeleteAsync(string id); // Deletes an entity if it belongs to the current user.