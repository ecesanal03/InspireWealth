using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InspireWealth.Services.DTOs;

namespace InspireWealth.Services.Interfaces
{
    public interface IStockService
    {
        Task<StockDTO> GetStockByIdAsync(string id);
        Task<IEnumerable<StockDTO>> GetAllStocksAsync();
        Task AddStockAsync(StockDTO stockDto);
        Task UpdateStockAsync(StockDTO stockDto);
        Task DeleteStockAsync(string id);
    }
}
