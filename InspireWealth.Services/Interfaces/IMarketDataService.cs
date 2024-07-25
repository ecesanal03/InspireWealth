using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspireWealth.Services.DTOs;

namespace InspireWealth.Services.Interfaces
{
    public interface IMarketDataService
    {
        Task<MarketDataDTO> GetMarketDataByIdAsync(string id);
        Task<IEnumerable<MarketDataDTO>> GetAllMarketDataAsync();
        Task AddMarketDataAsync(MarketDataDTO marketDataDto);
        Task UpdateMarketDataAsync(MarketDataDTO marketDataDto);
        Task DeleteMarketDataAsync(string id);
    }
}
